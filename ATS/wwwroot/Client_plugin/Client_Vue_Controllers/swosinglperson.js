let swosinglperson = new Vue({
    el: '#swosinglperson',
    data: {
        ViewId2: document.getElementById('getid').innerText,

        individualpersonList: [],
        commonpersondataList: [],
        viewsinglpersondatadata: [],     
        countone: "",
        counttwo: "",
        countthree: "",
        Totalcount:"",
    },
    methods: {

        individualperson() {
         
            axios.get('/Client/individualpersonlist/' + this.ViewId2).then(response => {
                this.individualpersonList = response.data;
                this.countone = this.StatusProcess.length;
                this.counttwo = this.statusPending.length;
                this.countthree = this.statusSettled.length;
                this.Totalcount = this.individualpersonList.length;
               
            });
        },

        commondatalistdata() {
            axios.get('/Client/commondatalist/' + this.ViewId2).then(response => {
                this.commonpersondataList = response.data;

            });
        },

        Viewdata(id) {

            console.log(id);
            axios.get('/Client/viewdata/' + id).then(response => {
                this.viewsinglpersondatadata = response.data;
                console.log(this.viewsinglpersondatadata)
            });
        },

        print() {

            var originalContents = document.body.innerHTML;
            var printContents = document.getElementById('print').innerHTML;


            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
            setTimeout("location.reload(true);", 1000);


            //var el = document.getElementById("print");
            //newwin = window.open("");
            //newwin.document.write(el.outerHTML);
            //newwin.print();
            //newwin.close();

        }

    },
    mounted() {
        this.individualperson(this.ViewId2);
        this.commondatalistdata(this.ViewId2);


    },
    computed: {
        totalAmount: function () {
            let total = [];
            Object.entries(this.individualpersonList).forEach(([key, val]) => {
                total.push(val.amount);

            });
            return total.reduce(function (total, num) {
                return total + num;

            }, 0);
        },

        //filteredPeople: function () {
        //    var vm = this;
        //    var category = vm.selectedCategory;
        //    console.log(this.individualpersonList);
        //    if (category === "1") {
        //        return vm.individualpersonList.filter(function (person) {
        //            return person.statusProcess === category;
        //        });
        //    }
        //},


        StatusProcess: function () {
            return this.individualpersonList.filter(function (person) {
                return person.statusProcess === "1";
            });
        },

        statusPending: function () {
            return this.individualpersonList.filter(function (person) {
                return person.statusPending === "2";
            });
        },

        statusSettled: function () {
            return this.individualpersonList.filter(function (person) {
                return person.statusSettled === "3";
            });
        }

    },

});