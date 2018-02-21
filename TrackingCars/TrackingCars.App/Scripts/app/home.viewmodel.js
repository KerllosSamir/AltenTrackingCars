function HomeViewModel(app, dataModel) {
    var self = this;

    self.customers = ko.observableArray([]);
    self.customersLookup = ko.observableArray([]);
    self.SC = new CustomerSearchCriteria();
    self.vehicleStatusLookup = [{ name: 'Disconnected', id: 0 }, { name: 'Connected', id: 1 }]



    self.SearchCustomer = function () {
        debugger;
        $.ajax({
            method: 'POST',
            data: ko.toJSON(self.SC),
            dataType: 'json',
            url: app.dataModel.userInfoUrl + "/GetCustomers",
            contentType: "application/json; charset=utf-8",
            headers: {
                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            },
            success: function (data) {
                //debugger;
                //self.customers(data);
                self.customers([]);
                //ko.mapping.fromJS(data, {}, self.customers);
                //ko.mapping.fromJS( data,self.customers, self);
                //ko.mapping.fromJS(data, self.customers);
                //self.customers = ko.mapping.fromJS(data);

                ko.utils.arrayForEach(data, function (item) {
                    self.customers.push(ko.viewmodel.fromModel(item));
                });


            }
        });
    }

    self.GetCustomerLookup = function () {
        $.ajax({
            method: 'Get',
            url: app.dataModel.userInfoUrl + "/GetCustomerLookup",
            contentType: "application/json; charset=utf-8",
            headers: {
                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            },
            success: function (res) {
                self.customersLookup(res);
            }
        });
    }

    self.StartHub = function () {
        $.connection.hub.url = "http://localhost:8089//signalr/hubs";

        // Declare a proxy to reference the hub.
        var chat = $.connection.trackingHub;

        // Create a function that the hub can call to broadcast messages.
        chat.client.SendVehicleStatus = function (vehicle) {

            //// Html encode display name and message.
            //var encodedName = $('<div />').text(vehicle.RegNo).html();
            //var encodedMsg = $('<div />').text(vehicle.ConnectioStatus).html();
            //// Add the message to the page.
            //$('#discussion').append('<li><strong>Recieved addMessage' + encodedName
            //    + '</strong>&nbsp;&nbsp;' + encodedMsg + '</li>');


            for (var j = 0; j < self.customers().length; j++) {

                for (var v = 0; v < self.customers()[j].vehicles().length; v++) {
                    if (self.customers()[j].vehicles()[v].regNo() == vehicle.RegNo) {
                        self.customers()[j].vehicles()[v].connectionStatus(vehicle.ConnectioStatus);
                        return;
                    }
                }

            }

        };

        $.connection.hub.start();
    }
    Sammy(function () {
        this.get('#home', function () {
            // Make a call to the protected Web API by passing in a Bearer Authorization Header
            self.SearchCustomer();
            self.GetCustomerLookup();
            try {
                self.StartHub();
            }
            catch (err) { }
        });
        this.get('/', function () { this.app.runRoute('get', '#home') });
    });

    return self;
}

function CustomerSearchCriteria() {
    var self = this;
    self.Id = ko.observable(0);
    self.Ids = ko.observableArray([]);
    self.ConnectionStatusId = ko.observable();
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
