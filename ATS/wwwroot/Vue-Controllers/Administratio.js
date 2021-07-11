let Administration = new Vue({
    el: '#Administration',
    data: {
        Role: {},
        RoleList: [],
        UserList:[],
        editdat: [],
        AuditList: [],
        checkData:[],
        ViewUserData:[],
        UserData: {},
        IsShowRole: true,
        IsShowUser: true,
        IsShowCancel: false,
        isMassage: false,
        isMassageuser: false,
        errorMassage: "",
        ClassStatus: "",
        Isauditsection: false,

        ClassName: "",
        messageName: "",
        ClassemployeeId: "",
        messageemployeeId: "",
        Classemail: "",
        messageemail: "",
        ClassjoiningDate: "",
        messagejoiningDate: "",
        ClassdateofBirth: "",
        messagedateofBirth: "",
        ClassmobileNo: "",
        messagemobileNo: "",
        ClassuserTypeId: "",
        messageuserTypeId: "",
    },



    methods: {
        UserCreate() {
            this.Validation();
            if (this.activeProject) {
                this.UserData.password = "Ats001";
                this.UserData.activeStatus = true;
                this.UserData.userCreateDate = "2020-01-20";
                this.UserData.userTypeId = String(this.UserData.userTypeId);
                //console.log(this.UserData);
                axios({
                    method: 'post',
                    url: '/Administration/CreateUser',
                    data: this.UserData
                }).then(response => {
                    console.log(response.data);
                    if (response.data == "required") {
                        this.errorMassage = "Required Item";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }

                    if (response.data == "mobileNo") {
                        this.errorMassage = "Already used Mobile No";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }
                    if (response.data == "employeeId") {
                        this.errorMassage = "Already used Employee Id";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }
                    if (response.data == "email") {
                        this.errorMassage = "Already used email";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }
                    if (response.data == "UserExit") {
                        this.errorMassage = "Already used Employee Id ";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }
                    if (response.data == "UserandAuditExit") {
                        this.errorMassage = "Already Exit User and Audit  ";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }

                    if (response.data == "Failed") {
                        this.errorMassage = "Failed ";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }

                    if (response.data == "Success") {
                        this.errorMassage = "User Create Success ";
                        this.ClassStatus = ['alert-success'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000);
                        this.GetAllUser();
                        this.UserData = {};
                    }

                })
            }
        },

        Validation() {
            var count = 0;
            if (this.UserData.name === "" || this.UserData.name === null || this.UserData.name === undefined) {
                this.messageName = "User Name Required";
                this.ClassName = ['text-danger'];
                count++;
            } else {
                this.messageName = "";
                this.ClassName = "";
            }

            if (this.UserData.employeeId === "" || this.UserData.employeeId === null || this.UserData.employeeId === undefined) {
                this.messageemployeeId = "Employee ID Required";
                this.ClassemployeeId = ['text-danger'];
                count++;
            } else {
                this.messageemployeeId = "";
                this.ClassemployeeId = "";
            }

            if (this.UserData.dateofBirth === "" || this.UserData.dateofBirth === null || this.UserData.dateofBirth === undefined) {
                this.messagedateofBirth = "Date of Birth Required";
                this.ClassdateofBirth = ['text-danger'];
                count++;
            } else {
                this.messagdateofBirth = "";
                this.ClassdateofBirth = "";
            }

            if (this.UserData.mobileNo === "" || this.UserData.mobileNo === null || this.UserData.mobileNo === undefined) {
                this.messagemobileNo = "Mobile No Required";
                this.ClassmobileNo = ['text-danger'];
                count++;
            } else {
                this.messagemobileNo = "";
                this.ClassmobileNo = "";
            }

            if (this.UserData.email === "" || this.UserData.email === null || this.UserData.email === undefined) {
                this.messageemail = "Email Required";
                this.Classemail = ['text-danger'];
                count++;
            } else {
                this.messageemail = "";
                this.Classemail = "";
            }

            if (this.UserData.joiningDate === "" || this.UserData.joiningDate === null || this.UserData.joiningDate === undefined) {
                this.messagejoiningDate = "Joining date Required";
                this.ClassjoiningDate = ['text-danger'];
                count++;
            } else {
                this.messagejoiningDate = "";
                this.ClassjoiningDate = "";
            }

            if (this.UserData.userTypeId === 0 || this.UserData.userTypeId === "0" || this.UserData.userTypeId === null || this.UserData.userTypeId === undefined) {
               
                this.messageuserTypeId = "User Type Required";
                this.ClassuserTypeId = ['text-danger'];
                count++;
            } else {
                this.messageuserTypeId = "";
                this.ClassuserTypeId = "";
            }

            

            if (count === 0) {
                this.activeProject = true;
            } else {
                this.activeProject = false;
            }
        },
        NameTextBoxOnChange() {
            if (this.UserData.name === "" || this.UserData.name === null || this.UserData.name === undefined) {
                this.messageName = "Name Required";
                this.ClassName = ['text-danger'];
            } else {
                this.messageName = "";
                this.ClassName = "";
            }
        },
        NameTextBoxKeyup() {
            if (this.UserData.name === "" || this.UserData.name === null || this.UserData.name === undefined) {
                this.messageName = "Name Required";
                this.ClassName = ['text-danger'];
            } else {
                this.messageName = "";
                this.ClassName = "";
            }
        },
        EmployeeIdTextBoxOnChange() {
            if (this.UserData.employeeId === "" || this.UserData.employeeId === null || this.UserData.employeeId === undefined) {
                this.messageemployeeId = "Employee ID Required";
                this.ClassemployeeId = ['text-danger'];
            } else {
                this.messageemployeeId = "";
                this.ClassemployeeId = "";
            }
        },
        EmployeeIdTextBoxKeyup() {
            if (this.UserData.employeeId === "" || this.UserData.employeeId === null || this.UserData.employeeId === undefined) {
                this.messageemployeeId = "Employee ID Required";
                this.ClassemployeeId = ['text-danger'];
            } else {
                this.messageemployeeId = "";
                this.ClassemployeeId = "";
            }
        },
        DateofBirthTextBoxOnChange() {
            if (this.UserData.dateofBirth === "" || this.UserData.dateofBirth === null || this.UserData.dateofBirth === undefined) {
                this.messagedateofBirth = "Date of Birth Required";
                this.ClassdateofBirth = ['text-danger'];
            } else {
                this.messagedateofBirth = "";
                this.ClassdateofBirth = "";
            }
        },
        DateofBirthTextBoxKeyup() {
            if (this.UserData.dateofBirth === "" || this.UserData.dateofBirth === null || this.UserData.dateofBirth === undefined) {
                this.messagedateofBirth = "Date of Birth Required";
                this.ClassdateofBirth = ['text-danger'];
            } else {
                this.messagedateofBirth = "";
                this.ClassdateofBirth = "";
            }
        },

        JoiningDateTextBoxOnChange() {
            if (this.UserData.joiningDate === "" || this.UserData.joiningDate === null || this.UserData.joiningDate === undefined) {
                this.messagejoiningDate = "Joining Date Required";
                this.ClassjoiningDate = ['text-danger'];
            } else {
                this.messagejoiningDate = "";
                this.ClassjoiningDate = "";
            }
        },
        JoiningDateTextBoxKeyup() {
            if (this.UserData.joiningDate === "" || this.UserData.joiningDate === null || this.UserData.joiningDate === undefined) {
                this.messagejoiningDate = "Joining Date Required";
                this.ClassjoiningDate = ['text-danger'];
            } else {
                this.messagejoiningDate = "";
                this.ClassjoiningDate = "";
            }
        },
        EmailTextBoxOnChange() {
            if (this.UserData.email === "" || this.UserData.email === null || this.UserData.email === undefined) {
                this.messageemail = "Email Required";
                this.Classemail = ['text-danger'];
            } else {
                var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                if (!re.test(this.UserData.email)) {
                    this.messageemail = "Invalid Email address";
                } else {
                    this.messageemail = "";
                    this.Classemail = "";
                }
            }
        },
        EmailTextBoxKeyup() {
            if (this.UserData.email === "" || this.UserData.email === null || this.UserData.email === undefined) {
                this.messageemail = "Email Required";
                this.Classemail = ['text-danger'];
            } else {
                this.messageemail = "";
                this.Classemail = "";
            }
        },
        MobileTextBoxOnChange() {
            if (this.UserData.mobileNo === "" || this.UserData.mobileNo === null || this.UserData.mobileNo === undefined) {
                this.messagemobileNo = "Mobile Required";
                this.ClassmobileNo = ['text-danger'];
            } else {
                var phoneno = /^\d{10}$/;
                if (this.UserData.mobileNo.match(phoneno)) {
                    this.messagemobileNo = "Invalid Mobile No";
                } else {
                    this.messagemobileNo = "";
                    this.ClassmobileNo = "";
                }
            }
        },
        MobileTextBoxKeyup() {
            if (this.UserData.mobileNo === "" || this.UserData.mobileNo === null || this.UserData.mobileNo === undefined) {
                this.messagemobileNo = "Mobile No Required";
                this.ClassmobileNo = ['text-danger'];
            } else {
                this.messagemobileNo = "";
                this.ClassmobileNo = "";
            }
        },
        userTypeIdOnchange() {
           if (this.UserData.userTypeId == 0 || this.UserData.userTypeId == null || this.UserData.userTypeId == undefined) {
                this.messageuserTypeId = "Required";
                this.ClassuserTypeId = ['text-danger'];
            } else {
                this.ClassuserTypeId = "";
                this.messageuserTypeId = "";
            }
        },
        update() {

            this.Validation();
            if (this.activeProject) {

                axios({
                    method: 'post',
                    url: '/Administration/updateuser',
                    data: this.UserData
                }).then(response => {


                    if (response.data == "required") {
                        this.errorMassage = "Required Item";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }

                    if (response.data == "mobileNo") {
                        this.errorMassage = "Already used Mobile No";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }
                    if (response.data == "employeeId") {
                        this.errorMassage = "Already used Employee Id";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }
                    if (response.data == "email") {
                        this.errorMassage = "Already used email";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }
                    if (response.data == "UserExit") {
                        this.errorMassage = "Already used Employee Id ";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }

                    if (response.data == "Failed") {
                        this.errorMassage = "Failed ";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassageuser = true;
                        setTimeout(() => this.isMassageuser = false, 2000)
                    }

                    if (response.data == "Success") {
                        this.errorMassage = "User Update Success ";
                        this.ClassStatus = ['alert-success'];
                        this.isMassageuser = true;
                        this.Isauditsection = false;
                        setTimeout(() => this.isMassageuser = false, 2000);
                        this.GetAllUser();
                    }

                })
            }
        },



        hidediv(id) {
            

            axios.get('/Administration/EditRole/' + id).then(response => {
                this.checkData = response.data;
                if (this.checkData != null) {
                    if (this.checkData.name == "Audit") {
                        this.Isauditsection = true;                     
                    } else {
                        this.Isauditsection = false;
                        this.UserData.auditId = 0;
                    }
                }
                else {
                    this.Isauditsection = false;
                }
                             
            })

           
        },


        GetAllUser() {
            axios({
                method: 'get',
                url: '/Administration/GetAllUser',
            }).then(response => {
                this.UserList = response.data;

            })
        },


        UserEdit(id) {            
            this.IsShowUser = false;
            this.IsShowCancel = true; 
            axios.get('/Administration/UserEdit/' + id).then(response => {
                this.hidediv(response.data.userTypeId);
                this.UserData = {
                    id: response.data.id,
                    name: response.data.name,
                    email: response.data.email,
                    mobileNo: response.data.mobileNo,
                    employeeId: response.data.employeeId,
                    userTypeId: response.data.userTypeId,
                    firstDesignation: response.data.firstDesignation,
                    currentDesignation: response.data.currentDesignation,
                    workplace: response.data.workplace,
                    dateofBirth: response.data.dateofBirth,
                    joiningDate: response.data.joiningDate,
                    auditId: response.data.auditId
                }
                console.log(this.UserData);
            });


            this.ClassName = "";
            this.messageName = "";
            this.ClassemployeeId = "";
            this.messageemployeeId = "";
            this.Classemail = "";
            this.messageemail = "";
            this.ClassjoiningDate = "";
            this.messagejoiningDate = "";
            this.ClassdateofBirth = "";
            this.messagedateofBirth = "";
            this.ClassmobileNo = "";
            this.messagemobileNo = "";
            this.ClassuserTypeId = "";
            this.messageuserTypeId = "";

        },

        ViewUser(id) {
            axios.get('/Administration/UserView/' + id).then(response => {
                this.ViewUserData = response.data;
            })
        },

        UserDelete: function (id) {
            var r = confirm("Do You Want to Delete");
            if (r === true) {
                axios.delete('/Administration/Removeuser/' + id).then(response => {
                    this.Cancel();
                    this.GetAllUser();
                });

            }
        },

        //Role create
        roleCreate() {
        
            axios({
                method: 'post',
                url: '/Administration/CreateRole',
                data: this.Role
            }).then(response => {
                if (response.data =="roleExit") {
                    this.errorMassage = "Role Exit";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "Succeeded") {
                    this.errorMassage = "Role Create Success ";
                    this.ClassStatus = ['alert-success'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000);
                    this.GetAllRole();
                    this.Role = {};
                }             
            })
        },

        GetAllRole() {
            axios({
                method: 'get',
                url: '/Administration/GetAllRole',
            }).then(response => {
                this.RoleList = response.data;
         
            })
        },
        GetAllAudit() {
            axios({
                method: 'get',
                url: '/Audit/GetAll',
            }).then(response => {
                this.AuditList = response.data;

            })
        },
        RoleEdit(id) {
            this.IsShowRole = false;
            this.IsShowCancel = true;
            axios.get('/Administration/EditRole/' + id).then(response => {
                
                this.editdat = response.data;         
                this.Role = {
                    id: response.data.id,
                    roleName: response.data.name,
                }

            });

        },

        roleUpdate() {
            axios({
                method: 'post',
                url: '/Administration/UpdateRole',
                data: this.Role
            }).then(response => {
                if (response.data == "roleExit") {
                    this.errorMassage = "Role Exit";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "Succeeded") {
                    this.errorMassage = "Role Update Success ";
                    this.ClassStatus = ['alert-success'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000);
                    this.GetAllRole();
                    this.Role = {};
                }

            })
        },

        Delete: function (id) {
            var r = confirm("Do You Want to Delete");
            if (r === true) {
                axios.delete('/Administration/Remove/' + id).then(response => {
                    this.Cancel();
                    this.GetAllRole();
                });

            }
        },
        Cancel() {
            this.IsShowRole = true;
            this.IsShowUser = true;
            this.IsShowCancel = false;          
            this.Role = {};
            this.UserData = {};

            this.ClassName = "";
            this.messageName = "";
            this.ClassemployeeId = "";
            this.messageemployeeId = "";
            this.Classemail = "";
            this.messageemail = "";
            this.ClassjoiningDate = "";
            this.messagejoiningDate = "";
            this.ClassdateofBirth = "";
            this.messagedateofBirth = "";
            this.ClassmobileNo = "";
            this.messagemobileNo = "";
            this.ClassuserTypeId = "";
            this.messageuserTypeId = "";
        }
    },
    mounted() {
        this.GetAllRole();
        this.GetAllUser();
        this.GetAllAudit();
        this.UserData.userTypeId = 0;
        this.UserData.auditId = 0;
    },
    computed: {

    }
})