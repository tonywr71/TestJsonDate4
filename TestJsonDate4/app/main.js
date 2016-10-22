var app;
(function (app) {
    var Main = (function () {
        function Main($http) {
            this.$http = $http;
            this.food = "Pizza";
            this.dateOptions = {
                dateDisabled: false,
                formatYear: 'yy',
                maxDate: new Date(2020, 5, 22),
                minDate: new Date(),
                startingDay: 1
            };
            this.popupOpened = false;
            this.getTheDate();
        }
        Object.defineProperty(Main.prototype, "theDate2", {
            get: function () {
                return this.theDate;
            },
            set: function (theDate) {
                this.theDate = theDate;
            },
            enumerable: true,
            configurable: true
        });
        Main.prototype.ProcessForm = function (form) {
            this.$http.post("/api/values/updatedatepost", JSON.stringify(this.theDate)).then(function (result) {
                console.log('saved');
            });
            //this.$http.get("/api/values/updatedateget?theDate=" + this.theDate).then((result: any) => {
            //    console.log("saved");
            //});
        };
        Main.prototype.openPopup = function () {
            this.popupOpened = true;
        };
        Main.prototype.getTheDate = function () {
            var _this = this;
            this.$http.get("/api/Values/5").then(function (result) {
                var newDateString = result.data;
                var newDate = new Date(newDateString);
                _this.theDate = newDate;
                //this.theDate = new Date(result.data);
                console.log(newDate);
                console.log(result.data);
            });
        };
        Main.$inject = ["$http"];
        return Main;
    }());
    app.Main = Main;
    angular.module('app').controller('Main', Main);
})(app || (app = {}));
//# sourceMappingURL=main.js.map