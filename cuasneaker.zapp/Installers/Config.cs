namespace cuasneaker.zapp.Installers
{
    using Duende.IdentityServer.Models;

    public static class Config
    {
        // Cấu hình các IdentityResource (OpenID Connect)
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
            new IdentityResources.OpenId(), // Thêm OpenID mặc định
            new IdentityResources.Profile()  // Thêm Profile để lấy thông tin người dùng
            };

        // Cấu hình các ApiScope (Các quyền mà API sẽ cung cấp)
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("api1", "My API") // Tạo ApiScope cho API với tên là "api1"
            };

        // Cấu hình các ApiResource (Định nghĩa API mà IdentityServer bảo vệ)
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
            new ApiResource("api1", "My API")
            {
                Scopes = { "api1" }
            }
            };

        // Cấu hình các Clients (Các ứng dụng sẽ sử dụng IdentityServer để xác thực)
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
            // Client ứng dụng Angular hoặc ứng dụng web (Implicit Flow)
            new Client
            {
                ClientId = "angular_spa", // ID của ứng dụng Angular
                ClientName = "Angular SPA Client",
                AllowedGrantTypes = GrantTypes.Implicit, // Sử dụng Implicit Flow (không cần client_secret)
                RedirectUris = { "http://localhost:4200/callback" }, // Đường dẫn Angular nhận mã token
                PostLogoutRedirectUris = { "http://localhost:4200" }, // Đường dẫn sau khi logout
                AllowedCorsOrigins = { "http://localhost:4200" }, // Địa chỉ của ứng dụng Angular
                AllowedScopes = { "openid", "profile", "api1" } // Quyền được cấp cho client (trong đó có API Scope "api1")
            },

            // Client ứng dụng API hoặc ứng dụng không có giao diện (Client Credentials Flow)
            new Client
            {
                ClientId = "api_client",
                ClientName = "API Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials, // Sử dụng Client Credentials Flow
                ClientSecrets = { new Secret("secret".Sha256()) }, // Secret để xác thực client
                AllowedScopes = { "api1" } // Quyền được cấp cho client
            }
            };
    }
}
