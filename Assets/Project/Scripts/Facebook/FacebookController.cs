using Facebook.Unity;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine;
using UnityEngine.SceneManagement;
using WonderGame.UI.Common;

namespace WonderGame.Facebook {
    public class FacebookController : MonoBehaviour {
        [SerializeField] private UIWindow _loginWindow;

        private void Start() {
            _loginWindow.Show();  // login ablak megjelenítése
            FB.Init();            // Facebook framework inicializálása
        }

        public void PerformFacebookLogin() {
            FB.LogInWithReadPermissions(new[] {"public_profile"}, AuthCallback);    // bejelentkezés "public_profile" olvasási engedéllyel
        }

        // Facebook login callback metódus
        private void AuthCallback(ILoginResult result) {
            if (FB.IsLoggedIn) {    // ha sikerült a bejelentkezés
                var accessToken = AccessToken.CurrentAccessToken;
                Debug.Log($"Facebook login successful. (User ID: {accessToken.UserId})");
                // az access tokennel bejelentkezünk a GameSparks backendbe
                new FacebookConnectRequest()
                    .SetAccessToken(accessToken.TokenString)
                    .Send(OnAuthenticationResponse);
            } else {                // ha nem sikerült a bejelentkezés
                Debug.LogError("Facebook login failed.");
            }
        }

        // GameSparks login callback metódus
        private void OnAuthenticationResponse(AuthenticationResponse response) {
            if (!response.HasErrors) {
                Debug.Log($"GameSparks authentication successful for user {response.DisplayName}.");
                SceneManager.LoadSceneAsync("Main Menu");
            } else {
                Debug.LogError($"Authentication error: {response.Errors.JSON}");
            }
        }
    }
}