using WonderGame.UI.Common;

namespace WonderGame.Facebook {
    public class FacebookLoginButton : ButtonBehaviour<FacebookController> {
        protected override void OnClick() {
            Controller.PerformFacebookLogin();
        }
    }
}