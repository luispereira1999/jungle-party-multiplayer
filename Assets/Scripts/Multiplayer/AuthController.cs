using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class AuthController : SingletonMonoBehaviour<AuthController>
{
    public string CurrentPlayerId { get; private set; }

    public async Task Connect()
    {
        try
        {
            await UnityServices.InitializeAsync();

            // ao usar um clone do projeto com o package ParrelSync,
            // � necess�rio mudar de perfil de autentica��o,
            // para for�ar o clone a entrar com um utilizador diferente
#if UNITY_EDITOR
            if (ParrelSync.ClonesManager.IsClone())
            {
                string customArgument = ParrelSync.ClonesManager.GetArgument();
                AuthenticationService.Instance.SwitchProfile($"Clone_{customArgument}_Profile");
            }
#else
            int randomNumber = Random.Range(1, 2000);
            AuthenticationService.Instance.SwitchProfile($"Profile_{randomNumber}");
#endif

            Debug.Log("Utilizador conectado com sucesso!");
        }
        catch (AuthenticationException exception)
        {
            Debug.LogException(exception);
        }
        catch (RequestFailedException exception)
        {
            Debug.LogException(exception);
        }
    }

    public async Task AuthenticateAnonymous()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            CurrentPlayerId = AuthenticationService.Instance.PlayerId;
            Debug.Log("Utilizador an�nimo autenticado com sucesso!" + " Player ID: " + CurrentPlayerId);
        }
        catch (AuthenticationException exception)
        {
            Debug.LogException(exception);
        }
        catch (RequestFailedException exception)
        {
            Debug.LogException(exception);
        }
    }
}