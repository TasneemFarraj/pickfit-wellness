using System.IdentityModel.Tokens.Jwt;

namespace FITTNESS.Authorization
{
    public class InformationToken
    {
        public static Response.JwtAuthResponse GetInfoUser(string strToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var JwtToken = handler.ReadJwtToken(strToken.Replace("Bearer ", ""));
            var InfoDecrypt = SecuredHelper.GetInfoFromToken(JwtToken.ToString());
            return InfoDecrypt;
        }
    }
}
