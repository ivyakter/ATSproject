let objectionedit = new Vue({
    el: '#objectionedit',
    data: {
        ViewId1: document.getElementById('Getid1').innerText,
        DepartmentList: [],
        PeojecttList: [],
        AuditList: [],
        Objection: {},
        DepartmentList: [],
        fillterAuditList: [],
        DivisionList: [],
        DistrictFilltetList: [],
        UpzilaFilltetList: [],
        year: "",
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",

        messageOfficialName: "",
        messageEmployeeID: "",
        messageDateofBirth: "",
        messageMobileNo: "",
        messageEmail: "",
        messageDepartment: "",
        messageAudit: "",
        messageProject: "",
        messageParagraph: "",
        messageTitleofObjection: "",
        messageObjectionforAmount: "",
        messageObjectionType: "",

        ClassOfficialName: "",
        ClassEmployeeID: "",
        ClassDateofBirth: "",
        ClassMobileNo: "",
        ClassEmail: "",
        ClassDepartment: "",
        ClassAudit: "",
        ClassProject: "",
        ClassParagraph: "",
        ClassTitleofObjection: "",
        ClassObjectionforAmount: "",
        ClassObjectionType:"",

    },
    methods: {

        GetAllDepartmentList() {
            axios({
                method: 'get',
                url: '/Department/GetAll',
            }).then(response => {
                this.DepartmentList = response.data;
                //console.log(this.DepartmentList);
            })
        },
        GetAllPeojecttList() {
            axios({
                method: 'get',
                url: '/Project/GetAll',
            }).then(response => {
                this.PeojecttList = response.data;
                //console.log(this.PeojecttList);
            })
        },

        GetAllAuditList() {
            axios({
                method: 'get',
                url: '/Audit/GetAll',
            }).then(response => {
                this.AuditList = response.data;

            })
        },
        GetAll() {
            axios({
                method: 'get',
                url: '/Objection/GetAll',
            }).then(response => {
                this.ObjectionList = response.data;

            })
        },

        GetAllDivision() {
            axios({
                method: 'get',
                url: '/Division/GetAll',
            }).then(response => {
                this.DivisionList = response.data;

            })
        },

        Edit(Id) {

            Id = this.ViewId1;
            axios.get('/Objection/Editobjection/' + Id).then(response => {
                this.GetDeparmentData(response.data.departmentId);
                this.DistrictFillterData(response.data.divisionId)
                this.UpazilaFillterData(response.data.districtId)
                this.Objection = {
                    id: response.data.id,
                    departmentId: response.data.departmentId,
                    projectId: response.data.projectId,
                    auditId: response.data.auditId,
                    divisionId: response.data.divisionId,
                    districtId: response.data.districtId,
                    upazilaId: response.data.upazilaId,
                    employeeId: response.data.employeeId,
                    firstdesignation: response.data.firstdesignation,
                    currentdesignation: response.data.currentdesignation,
                    para: response.data.para,
                    objectionType: response.data.objectionType,
                    officialName: response.data.officialName,
                    joiningDate: response.data.joiningDate,
                    dateofBirth: response.data.dateofBirth,
                    workplace: response.data.workplace,
                    mobileNo: response.data.mobileNo,
                    email: response.data.email,
                    years: response.data.years,
                    amount: response.data.amount,
                    objectionsubmissionsDate: response.data.objectionsubmissionsDate,
                    auditobjectioncreateDate: response.data.auditobjectioncreateDate,
                    auditobjectionsubmissionsDate: response.data.auditobjectionsubmissionsDate,
                    password: response.data.password,
                    status: response.data.status,
                    description: response.data.description,
                    title: response.data.title
                }

            });


        },

        Update() {
            this.Validation();
            if (this.activeProject) {
                this.Objection.password = "Ats" + this.Objection.employeeId + this.year;
                this.currentDate = new Date().toJSON().slice(0, 10).replace(/-/g, '-');
                this.Objection.objectionsubmissionsDate = this.currentDate;
                this.Objection.objectionsubmissionsDate = String(this.Objection.objectionsubmissionsDate);
                this.Objection.years = String(this.Objection.years);
                this.Objection.objectionType = String(this.Objection.objectionType);
                axios({
                    method: 'post',
                    url: '/Objection/Update',
                    data: this.Objection
                }).then(response => {
                    console.log(response.data);
                    if (response.data == "Failed") {
                        this.errorMassage = "Failed";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassage = true;
                        setTimeout(() => this.isMassage = false, 2000)

                    }
                    if (response.data == "required") {
                        this.errorMassage = "Required Data";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassage = true;
                        setTimeout(() => this.isMassage = false, 2000)
                    }

                    if (response.data == "name") {
                        this.errorMassage = "Officer Name Already Exists in another account";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassage = true;
                        setTimeout(() => this.isMassage = false, 2000)
                    }

                    if (response.data == "employeeId") {
                        this.errorMassage = "employee Id Already Exists";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassage = true;
                        setTimeout(() => this.isMassage = false, 2000)
                    }

                    if (response.data == "mobileNo") {
                        this.errorMassage = "Mobile No Already Exists";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassage = true;
                        setTimeout(() => this.isMassage = false, 2000)
                    }


                    if (response.data == "email") {
                        this.errorMassage = "Email Already Exists";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassage = true;
                        setTimeout(() => this.isMassage = false, 2000)
                    }

                    if (response.data == "title") {
                        this.errorMassage = "Title Exist same Officer objection";
                        this.ClassStatus = ['alert-danger'];
                        this.isMassage = true;
                        setTimeout(() => this.isMassage = false, 2000)
                    }

                    if (response.data == "Success") {
                        this.errorMassage = "Objection Update Success";
                        this.ClassStatus = ['alert-success'];
                        this.isMassage = true;
                        //this.Objection = {};
                        setTimeout(() => this.isMassage = false, 2000)
                    }
                })
            }
        },
        Validation() {
            var count = 0;
            if (this.Objection.officialName === "" || this.Objection.officialName === null || this.Objection.officialName === undefined) {
                this.messageOfficialName = "Official Name Required";
                this.ClassOfficialName = ['text-danger'];
                count++;
            } else {
                this.messageOfficialName = "";
            }

            if (this.Objection.employeeId === "" || this.Objection.employeeId === null || this.Objection.employeeId === undefined) {
                this.messageEmployeeID = "Employee ID Required";
                this.ClassEmployeeID = ['text-danger'];
                count++;
            } else {
                this.messageEmployeeID = "";
            }

            if (this.Objection.dateofBirth === "" || this.Objection.dateofBirth === null || this.Objection.dateofBirth === undefined) {
                this.messageDateofBirth = "Date of Birth Required";
                this.ClassDateofBirth = ['text-danger'];
                count++;
            } else {
                this.messageDateofBirth = "";
            }


            if (this.Objection.email === "" || this.Objection.email === null || this.Objection.email === undefined) {
                this.messageEmail = "Email Required";
                this.ClassEmail = ['text-danger'];
                count++;
            } else {
                this.messageEmail = "";
            }

            if (this.Objection.mobileNo === "" || this.Objection.mobileNo === null || this.Objection.mobileNo === undefined) {
                this.messageMobileNo = "Mobile No Required";
                this.ClassMobileNo = ['text-danger'];
                count++;
            } else {
                this.messageMobileNo = "";
                this.ClassMobileNo = "";
            }

            if (this.Objection.para === "" || this.Objection.para === null || this.Objection.para === undefined) {
                this.messageParagraph = "Paragraph Required";
                this.ClassParagraph = ['text-danger'];
                count++;
            } else {
                this.messageParagraph = "";
            }

            if (this.Objection.title === "" || this.Objection.title === null || this.Objection.title === undefined) {
                this.messageTitleofObjection = "Title of Objection Required";
                this.ClassTitleofObjection = ['text-danger'];
                count++;
            } else {
                this.messageTitleofObjection = "";
            }

            if (this.Objection.amount === "" || this.Objection.amount === null || this.Objection.amount === undefined) {
                this.messageObjectionforAmount = "Amount Required";
                this.ClassObjectionforAmount = ['text-danger'];
                count++;
            } else {
                this.messageObjectionforAmount = "";
            }

            if (this.Objection.departmentId == 0 || this.Objection.departmentId == null || this.Objection.departmentId == undefined) {
                this.messageDepartment = "Required";
                this.ClassDepartment = ['text-danger'];
                count++;
            } else {
                this.messageDepartment = "";
            }

            if (this.Objection.auditId == 0 || this.Objection.auditId == null || this.Objection.auditId == undefined) {
                this.messageAudit = "Required";
                this.ClassAudit = ['text-danger'];
                count++;
            } else {
                this.messageAudit = "";
            }

            if (this.Objection.projectId == 0 || this.Objection.projectId == null || this.Objection.projectId == undefined) {
                this.messageProject = "Required";
                this.ClassProject = ['text-danger'];
                count++;
            } else {
                this.messageProject = "";
            }

            if (this.Objection.objectionType == 0 || this.Objection.objectionType == null || this.Objection.objectionType == undefined) {
                this.messageObjectionType = "Required";
                this.ClassObjectionType = ['text-danger'];
                count++;
            } else {
                this.messageObjectionType = "";
            }

            if (count === 0) {
                this.activeProject = true;
            } else {
                this.activeProject = false;
            }
        },
        EmailTextBoxOnChange() {
            if (this.Objection.email === "" || this.Objection.email === null || this.Objection.email === undefined) {
                this.messageEmail = "Email Required";
                this.ClassEmail = ['text-danger'];
            } else {
                var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                if (!re.test(this.Objection.email)) {
                    this.messageEmail = "Invalid Email address";
                } else {
                    this.messageEmail = "";
                    this.ClassEmail = "";
                }
            }
        },
        EmailTextBoxKeyup() {
            if (this.Objection.email === "" || this.Objection.email === null || this.Objection.email === undefined) {
                this.messageEmail = "Email Required";
                this.ClassEmail = ['text-danger'];
            } else {
                this.messageEmail = "";
                this.ClassEmail = "";
            }
        },
        MobileTextBoxOnChange() {
            if (this.Objection.mobileNo === "" || this.Objection.mobileNo === null || this.Objection.mobileNo === undefined) {
                this.messageMobileNo = "Mobile Required";
                this.ClassEmail = ['text-danger'];
            } else {
                var phoneno = /^\d{10}$/;
                if (this.Objection.mobileNo.match(phoneno)) {
                    this.messageMobileNo = "Invalid Mobile No";
                } else {
                    this.messageMobileNo = "";
                    this.ClassMobileNo = "";
                }
            }
        },
        MobileTextBoxKeyup() {
            if (this.Objection.mobileNo === "" || this.Objection.mobileNo === null || this.Objection.mobileNo === undefined) {
                this.messageMobileNo = "Mobile No Required";
                this.ClassMobileNo = ['text-danger'];
            } else {
                this.messageMobileNo = "";
                this.ClassMobileNo = "";
            }
        },
        OfficialNameTextBoxOnChange() {
            if (this.Objection.officialName === "" || this.Objection.officialName === null || this.Objection.officialName === undefined) {
                this.messageOfficialName = "Official Name Required";
                this.ClassOfficialName = ['text-danger'];
            } else {
                this.messageOfficialName = "";
                this.ClassOfficialName = "";
            }
        },
        OfficialNameTextBoxKeyup() {
            if (this.Objection.officialName === "" || this.Objection.officialName === null || this.Objection.officialName === undefined) {
                this.messageOfficialName = "Official Name Required";
                this.ClassOfficialName = ['text-danger'];
            } else {
                this.messageOfficialName = "";
                this.ClassOfficialName = "";
            }
        },
        EmployeeIDTextBoxOnChange() {
            if (this.Objection.employeeId === "" || this.Objection.employeeId === null || this.Objection.employeeId === undefined) {
                this.messageEmployeeID = "Employee ID Required";
                this.ClassEmployeeID = ['text-danger'];
            } else {
                this.messageEmployeeID = "";
                this.ClassEmployeeID = "";
            }
        },
        EmployeeIDTextBoxKeyup() {
            if (this.Objection.employeeId === "" || this.Objection.employeeId === null || this.Objection.employeeId === undefined) {
                this.messageEmployeeID = "Employee ID Required";
                this.ClassEmployeeID = ['text-danger'];
            } else {
                this.messageEmployeeID = "";
                this.ClassEmployeeID = "";
            }
        },
        DateofBirthTextBoxOnChange() {
            if (this.Objection.dateofBirth === "" || this.Objection.dateofBirth === null || this.Objection.dateofBirth === undefined) {
                this.messageDateofBirth = "Date of Birth Required";
                this.ClassDateofBirth = ['text-danger'];
            } else {
                this.messageDateofBirth = "";
                this.ClassDateofBirth = "";
            }
        },
        DateofBirthTextBoxKeyup() {
            if (this.Objection.dateofBirth === "" || this.Objection.dateofBirth === null || this.Objection.dateofBirth === undefined) {
                this.messageDateofBirth = "Date of Birth Required";
                this.ClassDateofBirth = ['text-danger'];
            } else {
                this.messageDateofBirth = "";
                this.ClassDateofBirth = "";
            }
        },
        ParagraphTextBoxOnChange() {
            if (this.Objection.para === "" || this.Objection.para === null || this.Objection.para === undefined) {
                this.messageParagraph = "Paragraph Required";
                this.ClassParagraph = ['text-danger'];
            } else {
                this.messageParagraph = "";
                this.ClassParagraph = "";
            }
        },
        ParagraphTextBoxKeyup() {
            if (this.Objection.para === "" || this.Objection.para === null || this.Objection.para === undefined) {
                this.messageParagraph = "Paragraph Required";
                this.ClassParagraph = ['text-danger'];
            } else {
                this.messageParagraph = "";
                this.ClassParagraph = "";
            }
        },
        TitleofObjectionTextBoxOnChange() {
            if (this.Objection.title === "" || this.Objection.title === null || this.Objection.title === undefined) {
                this.messageTitleofObjection = "Title of Objection Required";
                this.ClassTitleofObjection = ['text-danger'];
            } else {
                this.messageTitleofObjection = "";
                this.ClassTitleofObjection = "";
            }
        },
        TitleofObjectionTextBoxKeyup() {
            if (this.Objection.title === "" || this.Objection.title === null || this.Objection.title === undefined) {
                this.messageTitleofObjection = "Title of Objection Required";
                this.ClassTitleofObjection = ['text-danger'];
            } else {
                this.messageTitleofObjection = "";
                this.ClassTitleofObjection = "";
            }
        },
        ObjectionforAmountTextBoxOnChange() {
            if (this.Objection.amount === "" || this.Objection.amount === null || this.Objection.amount === undefined) {
                this.messageObjectionforAmount = "Amount Required";
                this.ClassObjectionforAmount = ['text-danger'];
            } else {
                this.messageObjectionforAmount = "";
                this.ClassObjectionforAmount = "";
            }
        },
        ObjectionforAmountTextBoxKeyup() {
            if (this.Objection.amount === "" || this.Objection.amount === null || this.Objection.amount === undefined) {
                this.messageObjectionforAmount = "Amount Required";
                this.ClassObjectionforAmount = ['text-danger'];
            } else {
                this.messageObjectionforAmount = "";
                this.ClassObjectionforAmount = "";
            }
        },
        AuditOnChange() {
            if (this.Objection.auditId == 0 || this.Objection.auditId == null || this.Objection.auditId == undefined) {
                this.messageAudit = "Required";
                this.ClassAudit = ['text-danger'];
            } else {
                this.messageAudit = "";
                this.ClassAudit = "";
            }
        },
        ProjectOnChange() {
            if (this.Objection.projectId == 0 || this.Objection.projectId == null || this.Objection.projectId == undefined) {
                this.messageProject = "Required";
                this.ClassProject = ['text-danger'];
            } else {
                this.ClassProject = "";
                this.messageProject = "";
            }
        },
        ObjectionTypeOnChange() {
            if (this.Objection.objectionType == 0 || this.Objection.objectionType == null || this.Objection.objectionType == undefined) {
                this.messageObjectionType = "Required";
                this.ClassObjectionType = ['text-danger'];
            } else {
                this.messageObjectionType = "";
                this.ClassObjectionType = "";
            }
        },

        Cancle() {
            window.location.href = "/Objection";
        },


        GetDeparmentData(id) {
            if (id > 0) {
                axios.get('/Audit/filter/' + id).then(response => {
                    this.fillterAuditList = response.data;
                    //console.log(this.fillterAuditList);
                }); 
            }
            this.Objection.auditId = 0;
                     
        },


        DistrictFillterData(id) {
            if (id>0) {
                axios.get('/District/filter/' + id).then(response => {
                    this.DistrictFilltetList = response.data;
                    //console.log(this.DistrictFilltetList);
                
                });
            }
            this.Objection.upazilaId = 0;
            this.Objection.districtId = 0;
        },
        UpazilaFillterData(id) {
            axios.get('/Upzila/filter/' + id).then(response => {
                this.UpzilaFilltetList = response.data;
                //console.log(this.DistrictFilltetList);
            });

        }
    },
    mounted() {
        this.GetAllDepartmentList();
        this.GetAllPeojecttList();
        this.GetAllAuditList();

        if (this.ViewId1 != "") {
            this.Edit(this.ViewId1);
        }
        this.GetAllDivision();
        this.GetDeparmentData();
        this.year = (new Date().getFullYear());
        this.Objection.departmentId = 0;
        this.Objection.auditId = 0;
        this.Objection.projectId = 0;
        this.Objection.objectionType = 0;
        this.Objection.divisionId = 0;
        this.Objection.districtId = 0;
        this.Objection.upazilaId = 0;
    },


})