module app {

    export class Main {

        static $inject = ["$http"];
        constructor(private $http: ng.IHttpService) {
            this.getTheDate();
        }

        public food: string = "Pizza";
        public theDate: Date;

        public get theDate2(): Date {
            return this.theDate;
        }

        public set theDate2(theDate: Date) {
            this.theDate = theDate;
        }

        public ProcessForm(form: ng.IFormController): void {
            var data = JSON.stringify(this.theDate);
            this.$http.post("/api/values/updatedatepost", data).then((result: any) => {
                console.log('saved');
            });
            //this.$http.get("/api/values/updatedateget?theDate=" + this.theDate).then((result: any) => {
            //    console.log("saved");
            //});
        }

        public dateOptions: any = {
            dateDisabled: false,
            formatYear: 'yy',
            maxDate: new Date(2020, 5, 22),
            minDate: new Date(),
            startingDay: 1
        };

        public popupOpened: boolean = false;

        public openPopup(): void {
            this.popupOpened = true;
        }

        public getTheDate(): void {
            this.$http.get("/api/Values/5").then((result: any) => {
                var newDateString: string = result.data;
                var newDate: Date = new Date(newDateString);
                this.theDate = newDate;
                //this.theDate = new Date(result.data);
                console.log(newDate);
                console.log(result.data);
            });
        }

    }

    angular.module('app').controller('Main', Main);

}