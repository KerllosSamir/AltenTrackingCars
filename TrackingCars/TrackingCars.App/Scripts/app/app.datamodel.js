function AppDataModel() {
    var self = this;
    // Routes
    self.userInfoUrl = "/api/Customer";
    self.siteUrl = "/";
    
    //ko.viewmodel.fromModel(@Html.Raw(Json.Encode(new UIClientConnectionStringSC() { })));
    // Route operations

    // Other private operations

    // Operations

    // Data
    self.returnUrl = self.siteUrl;

    // Data access operations
    self.setAccessToken = function (accessToken) {
        sessionStorage.setItem("accessToken", accessToken);
    };

    self.getAccessToken = function () {
        return sessionStorage.getItem("accessToken");
    };
}

