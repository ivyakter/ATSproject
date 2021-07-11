let EMPProfile = new Vue({
    el: '#EMPProfile',
    data: {
        ViewId1: document.getElementById('getidname').innerText,
        EMPId: "",
        NewObjectionList: [],
        CountObjectionList:[],
        ProcessObjectionList: [],
        PanddingObjectionList: [],
        SettledObjectionList: [],
        commondataList:[],
        timestamp:"",
        passid: "",
        ReplyEMP: {},
        Countdata: "",
        CountProcess: "",
        CountPandding: "",
        CountSettled:"",
        ReplyobjectionViewdata: [],
        editprofile: {},
        collection: "",
        isMassage: false,
       
        errorMassage: "",
        ClassStatus: "",
        title:"",
    },
    methods: {

        NewObjection() {

            axios.get('/EmployeeProfile/NewObjectionGet/' + this.ViewId1).then(response => {
                this.NewObjectionList = response.data;                
            });

        },


        commondataData() {

            axios.get('/EmployeeProfile/commondataGet/' + this.ViewId1).then(response => {
                this.commondataList= response.data;
            });

        },

        TotalObjection(id) {
            window.location.href = "/Client/swoSingalperson/" + id;
        },



        COuntObjection() {
           
            axios.get('/EmployeeProfile/CountObjection/' + this.ViewId1).then(response => {
                this.CountObjectionList = response.data;
             
                this.Countdata = this.CountObjectionList.length;
            });
        },

          ProcessCountObjection(){
            axios.get('/EmployeeProfile/ProcessofObjection/' + this.ViewId1).then(response => {
                this.ProcessObjectionList = response.data;
                this.CountProcess = this.ProcessObjectionList.length;

                });
        },
          PendingofObjection() {
            axios.get('/EmployeeProfile/PendingofObjection/' + this.ViewId1).then(response => {
                this.PanddingObjectionList = response.data;
                this.CountPandding = this.PanddingObjectionList.length;
             

            });
        },

        SettledofObjection() {
            axios.get('/EmployeeProfile/SettledofObjection/' + this.ViewId1).then(response => {
                this.SettledObjectionList = response.data;
                this.CountSettled = this.SettledObjectionList.length;

            });
        },


        ReplyobjectionViewdataforsignal(id) {
                  axios.get('/EmployeeProfile/ReplyObjection/' + id).then(response => {
                      this.ReplyobjectionViewdata = response.data;
                     
                  });
        },

        userprofileUptefordata() {       
            axios.get('/EmployeeProfile/profileUpdate/' + this.ViewId1).then(response => {
                this.editprofile={
                    id: response.data.id,
                    workplace:response.data.workplace,
                    firstdesignation: response.data.firstdesignation,
                    currentdesignation: response.data.currentdesignation,
                }
                this.collection = this.editprofile.id;
            });
        },

        userprofileUpte() {
            this.editprofile.id = this.collection;
            axios({
                method: 'post',
                url: '/EmployeeProfile/Updateprofile',
                data: this.editprofile
            }).then(response => {
                if (response.data == "Success") {
                    this.isMassage = true;
                    this.errorMassage = "Update Success";
                    this.ClassStatus = ['alert-success'];
                  
                    setTimeout(() => this.isMassage = false, 2000)
                    this.commondataData();
                }
                if (response.data == "NotFound") {
                    this.isMassage = true;
                    this.errorMassage = "Not Found User";
                    this.ClassStatus = ['alert-danger']; -
                    setTimeout(() => this.isMassage = false, 2000)
                }

            }) 
        },

     
        Update() {
            this.ReplyEMP.id = this.ReplyobjectionViewdata.id;       
            this.ReplyEMP.employeeReplyDate = this.timestamp;
            this.ReplyEMP.employeeId = this.EMPId;
            this.ReplyEMP.title =this.ReplyobjectionViewdata.title;
            console.log(this.ReplyEMP);
            axios({
                method: 'post',
                url: '/EmployeeProfile/Update',
                data: this.ReplyEMP
            }).then(response => {
                if (response.data == "Success"){
                    this.isMassage = true;
                    this.errorMassage = "Update Success";
                    this.ClassStatus = ['alert-success'];
                    this.NewObjection();
                    this.ProcessCountObjection();
                    this.PendingofObjection();
                    this.ReplyEMP = {};
                
                    setTimeout(() => this.isMassage = false, 2000)                   
                }
                if (response.data == "Failed"){
                    this.isMassage = true;
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger']; 
                   
                    setTimeout(() => this.isMassage = false, 2000)
                    
                }

            })
        },
        getNow: function () {
            const today = new Date();
            const date = today.getDate() + '-' + (today.getMonth() + 1) + '-' + today.getFullYear();
            const time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            const dateTime = date + ' ' + time;
            this.timestamp = dateTime;
            console.log(this.timestamp);
        }
    },

    mounted() {
        this.getNow();
        this.NewObjection(this.ViewId1);
        this.COuntObjection(this.ViewId1);
        this.ProcessCountObjection(this.ViewId1);
        this.PendingofObjection(this.ViewId1);
        this.SettledofObjection(this.ViewId1);
        this.commondataData(this.ViewId1);
        this.userprofileUptefordata(this.ViewId1);
        //this.Allstatuscount();
        this.EMPId =this.ViewId1;
    },
    computed: {
        total: function () {
            let total = [];
            Object.entries(this.CountObjectionList).forEach(([key, val]) => {
                total.push(val.amount);
            });
            return total.reduce(function (total, num) {
                return total + num;
            }, 0);
        },

        

    }
})