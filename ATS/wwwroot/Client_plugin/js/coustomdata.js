var app = new Vue({
  el: "#mainid",
  data: {
    categoty: [
      { id: 1, name: "FAPAD" },
      { id: 2, name: "LAD" },
      { id: 3, name: "Internal" },
    ],

    mainProjectList: [
      { id: 1, name: "HPNSP" },
      { id: 2, name: "FPSD" },
      { id: 3, name: "USAID" },
      { id: 4, name: "BSAID" },
      { id: 5, name: "FP Main Scheem " },
    ],
    yearsList: [
      { id: 1, name: "2020" },
      { id: 2, name: "2019" },
      { id: 3, name: "2018" },
      { id: 4, name: "2017" },
      { id: 5, name: "2016" },
    ],
    DivisionList: [
      { id: 1, name: "Dhaka" },
      { id: 2, name: "Chittagong" },
      { id: 3, name: "Barishal" },
      { id: 4, name: "Khulna" },
      { id: 5, name: "Jessore " },
    ],
    EmpList: [
      {
        id: 1,
        img: "pdf/lad10-111.jpg",
        employeeId: "ATS0001",
        name: "Ahammed Ali",
        pera: "001",
        designation: "Divisional officer",
        posting: "Savar Upazila",
        years: "2017",
        amount: 59900000,
        titel:
          "Irregular expenditure amounting to TK.25,99,00,000.00 procurement",
        date: "2020-07-10",
        division: "Dhaka",
        district: "Dhaka",
        upazila: "Mohamoddpur Upazila",
        projectId: 1,
        projectname: "HPNSP",
        categotyId: 1,
        categotyname: "FAPAD",
        status: 1,
        password: "ATS0001",
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 59900000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },
      {
        id: 2,
        img: "pdf/lad10-112.jpg",
        employeeId: "ATS0002",
        name: "Shakil KHAN",
        designation: "Divisional officer",
        pera: "002",
        posting: "Savar Upazila",
        years: "2020",
        amount: 209900000,
        titel:
          "Irregular expenditure amounting to TK.30,99,00,000.00 procurement",     
        date: "2019-17-10",
        division: "Dhaka",
        district: "Dhaka",
        upazila: "Savar Upazila",
        projectId: 2,
        projectname: "FPSD",
        categotyId: 1,
        categotyname: "FAPAD",
        status: 2,
        password: "ATS0002",
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 209900000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },

      {
        id: 3,
        img: "pdf/lad10-113.jpg",
        employeeId: "ATS0003",
        name: "Zubayer Parvez",
        designation: "Divisional officer",
        posting: "Dhaka",
        years: "2017",
        pera: "003",
        amount: 159900000,
        titel:
          "Irregular expenditure amounting to TK.20,99,00,000.00 procurement",
        date: "2018-17-10",
        division: "Khulna",
        district: "Meherpur",
        upazila: "Meherpur Upazila",
        projectId: 3,
        projectname: "USAID",
        categotyId: 1,
        categotyname: "FAPAD",
        password: "ATS0003",
        status: 3,
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 159900000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },

      {
        id: 4,
        img: "pdf/lad10-114.jpg",
        employeeId: "ATS0004",
        name: "Joy Molla",
        designation: "District officer",
        posting: "Kushtia Upazila",
        years: "2020",
        pera: "004",
        amount: 409000000,
        titel:
          "Irregular expenditure amounting to TK.40,90,00,000.00 procurement",
        date: "2018-15-12",
        division: "Dhaka",
        district: "Madaripur",
        upazila: "Madaripur Upazila",
        projectId: 4,
        projectname: "BSAID",
        categotyId: 2,
        categotyname: "LAD",
        status: 2,
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, BSAID for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 409000000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },

      {
        id: 5,
        img: "pdf/lad10-115.jpg",
        employeeId: "ATS0005",
        name: "Sobuj Ali",
        designation: "Divisional officer",
        posting: "Savar Upazila",
        years: "2016",
        pera: "005",
        amount: 109900000,
        titel:
          "Irregular expenditure amounting to TK.10,99,00,000.00 procurement",
        date: "2018-17-10",
        division: "Barishal",
        district: "Bhola",
        upazila: "Bhola Upazila",
        projectId: 1,
        projectname: "HPNSP",
        categotyId: 2,
        categotyname: "LAD",
        status: 1,
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 109900000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },

      {
        id: 6,
        img: "pdf/lad10-116.jpg",
        employeeId: "ATS0006",
        name: "Jisan Khan",
        designation: "Divisional officer",
        posting: "Chadpur Upazila",
        years: "2017",
        pera: "007",
        amount: 509900000,
        titel:
          "Irregular expenditure amounting to TK.50,99,00,000.00 procurement",
        date: "2018-10-12",
        division: "Chittagong",
        district: "Chadpur",
        upazila: "Chadpur Upazila",
        projectId: 1,
        projectname: "HPNSP",
        categotyId: 3,
        categotyname: "Internal",
        status: 2,
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 509900000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },

      {
        id: 7,
        img: "pdf/lad10-117.jpg",
        employeeId: "ATS0007",
        name: "Alve Ahamed",
        designation: "DD",
        posting: "Panba Upazila",
        years: "2018",
        pera: "008",
        amount: 409800000,
        titel:
          "Irregular expenditure amounting to TK.40,99,00,000.00 procurement",
        date: "2018-10-08",
        division: "Chittagong",
        district: "Chadpur",
        upazila: "Chadpur Upazila",
        projectId: 4,
        projectname: "BSAID",
        categotyId: 2,
        categotyname: "LAD",
        status: 3,
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, BSAID for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 509900000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },

      {
        id: 8,
        img: "pdf/lad10-118.jpg",
        employeeId: "ATS0008",
        name: "Polok Ahamed",
        designation: "DD",
        posting: "Monshiganj",
        years: "2019",
        pera: "009",
        amount: 109000000,
        titel:
          "Irregular expenditure amounting to TK.10,99,00,000.00 procurement",
        date: "2019-10-10",
        division: "Dhaka",
        district: "Monshiganj",
        upazila: "Monshiganj Upazila",
        projectId: 5,
        projectname: "fP Main Scheem",
        categotyId: 3,
        categotyname: "Internal",
        status: 2,
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, BSAID for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 109000000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },

      {
        id: 9,
        img: "pdf/lad10-119.jpg",
        employeeId: "ATS0009",
        name: "Rabbani Ahamed",
        designation: "DG",
        posting: "Dhaka",
        years: "2017",
        pera: "009",
        amount: 209000000,
        titel:
          "Irregular expenditure amounting to TK.20,99,00,000.00 procurement",
        date: "2019-10-10",
        division: "Dhaka",
        district: "Dhaka",
        upazila: "Narayanganj Upazila",
        projectId: 3,
        projectname: "USAID",
        categotyId: 3,
        categotyname: "fAPAD",
        status: 1,
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, BSAID for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 209000000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },

      {
        id: 10,
        img: "pdf/lad10-120.jpg",
        employeeId: "ATS0010",
        name: "Shofiq Ahamed",
        designation: "DD",
        posting: "Dhaka",
        years: "2017",
        pera: "0010",
        amount: 209000000,
        titel:
          "Irregular expenditure amounting to TK.20,99,00,000.00 procurement",
        date: "2018-10-10",
        division: "Dhaka",
        district: "Dhaka",
        upazila: "Saver Upazila",
        projectId: 3,
        projectname: "FPSD",
        categotyId: 3,
        categotyname: "fAPAD",
        status: 1,
        descriptionOne:
          "Audit was conducted on the accounts of the Clinical Contraception Service Delivery Program under HPNSP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, BSAID for the Financial year 2014-2015.",
        descriptionTwo:
          "Bill/Vouchers, Tender document, contract agreement and other related documents were examined",
        descriptionThree:
          "Audited documents showed that the local authority paid amounting to Tk. 209000000 to Essential Drug Company limited (EDCL )for procurement of medicine- (Paracetamol 500 mg)",
      },
    ],
    mm: [],
    Category: "",
    Projec: "",
    Years: "",
    search: "",
    Division: "",
    startDate: null,
    endDate: null,
    Veiwitemlist: [],
    audit: "Select Aduit",
    Projecselect: "Select project",
    Yearsselect: "Select Years",
    DivisionSelect: "Select Division",
    logindata: { employeeI: "" },
    pas: "",
    empid: "",
    showsalert: false,
    emppassword: {},
    passid: "",
    emplistid: "",
    emplistpass: "",
    fa: "",
    fatwo: "",
    fathree: "",
    countone: "",
    counttwo: "",
    countthree: "",
    count: "",
    isActive: false,
    isproject: false,
    showsClear: false,
    countempobjarbation: "",
    countemployee: "",
  },

  methods: {
    login() {
      this.empid = this.logindata.employeeId;
      this.pas = this.logindata.password;
      this.emppassword = this.EmpList.find((k) => k.employeeId === this.empid);
      this.passid = this.emppassword.id;
      this.emplistid = this.emppassword.employeeId;
      this.emplistpass = this.emppassword.password;

      if (
        this.empid === this.emplistid &&
        this.pas === this.emppassword.emplistpass
      ) {
        window.location.href = "viewcase.html?id=" + this.passid;
      } else {
        this.showsalert = true;
        setTimeout(() => (this.showsalert = false), 3000);
      }
    },
    view(m) {
      var Veiwitem = this.EmpList.find((k) => k.id === m);
      this.Veiwitemlist = Veiwitem;
      console.log(this.Veiwitemlist);
      this.countempobjarbation = this.Veiwitemlist.employeeId;
      this.countemployee = this.countemployeeobjarbation.length;
      },

    filtergg() {
      this.Category = "All";
      this.Projec = "All";
      this.audit = "All";
      this.Years = "All";
      this.Division = "All";
      this.Projecselect = "Select project";
      this.Yearsselect = "Select Years";
      this.DivisionSelect = "Select Division";
      this.fa = 1;
      this.fatwo = 2;
      this.fathree = 3;
      this.countItem();
      this.isActive = true;
      this.showsClear = true;
      },

    filterg(id) {
      this.Category = id;
      this.audit = id;
      this.fa = 1;
      this.fatwo = 2;
      this.fathree = 3;
      console.log(this.fa);
      this.countItem();
      this.isActive = true;
      this.showsClear = true;
    },

    filterproject(id) {
      this.Projec = id;
      this.Projecselect = id;
      this.fa = 1;
      this.fatwo = 2;
      this.fathree = 3;
      this.countItem();
      this.isproject = true;
      this.showsClear = true;
      },

    FlitterProductByCategory() {
      this.countItem();
      this.showsClear = true;
      },

    FlitterProductByCategorya() {
      this.countItem();
      this.showsClear = true;
      },

    FlitterProductByCategoryb() {
      this.countItem();
      this.showsClear = true;
      },

    years(name) {
      this.Years = name;
      this.Yearsselect = name;
      this.countItem();
      },

    divisionfilter(g) {
      this.Division = g;
      this.DivisionSelect = g;
      this.countItem();
      },

    ClearAll() {
      this.Category = "All";
      this.Projec = "All";
      this.Projecselect = "Select project";
      (this.audit = "Select Aduit"), (this.isproject = false);
      this.isActive = false;
      this.endDate = null;
      this.startDate = null;
      this.search = "";
      this.countItem();
      this.showsClear = false;
    },
    ExportPdf: function () {
      var List = [
        { name: "Name", dataKey: "name", header: "Name" },
        {
          categotyname: "categotyname",
          dataKey: "categotyname",
          header: "Aduit",
        },
        { project: "projectname", dataKey: "projectname", header: "Project" },
        { titel: "Titel", dataKey: "titel", header: "Titel" },
      ];
      var doc = new jsPDF();
      doc.setFontSize(9);
      doc.setFontStyle("normal");
      doc.text("26-07-2020", 15, 15,);
      doc.setFontSize(12);
      doc.text("Objection List", 15,20,);
      doc.autoTable(List, this.filteredPeople, {
        margin: { top:25 },
        styles: { fontSize: 10 },
      });
      doc.save("ATS.pdf");
    },
    countItem() {
      this.countone = this.statusone.length;
      this.counttwo = this.statutwo.length;
      this.countthree = this.statuthree.length;
      this.count = this.filteredPeople.length;
    },
  },

  mounted() {
    this.Category = "All";
    this.Projec = "All";
    this.Years = "All";
    this.Division = "All";
    this.fa = 1;
    this.fatwo = 2;
    this.fathree = 3;
    this.countItem();
  },
  computed: {
    filteredPeople: function () {
      var vm = this;
      var years = vm.Years;
      var division = vm.Division;
      var project = vm.Projec;
      var category = vm.Category;
      var startDate = vm.startDate;
      var endDate = vm.endDate;
      console.log(years);
          if (category === "All" && project === "All" && years === "All" && division === "All") {

        return vm.EmpList.filter(function (item) {
          return (
            item.employeeId.toLowerCase().indexOf(vm.search.toLowerCase()) >= 0
          );
        }).filter(function (proList) {
          // console.log(startDate);
          // console.log(endDate);
          // console.log(proList.date);

          if (startDate == null && startDate == null) {
            return true;
          } else {
            return proList.date >= startDate && proList.date <= endDate;
          }
        });
      } else {
        return vm.EmpList.filter(function (productList) {
          return (
            (category === "All" || productList.categotyname === category) &&
            (project === "All" || productList.projectname === project) &&
            (years === "All" || productList.years === years) &&
            (division === "All" || productList.division === division)
          );
        })

          .filter(function (item) {
            return (
              item.employeeId.toLowerCase().indexOf(vm.search.toLowerCase()) >=
              0
            );
          })
          .filter(function (proList) {
            if (startDate == null && startDate == null) {
              return true;
            } else {
              return proList.date >= startDate && proList.date <= endDate;
            }
          });
      }
      },



    total: function () {
      let total = [];
      Object.entries(this.filteredPeople).forEach(([key, val]) => {
        total.push(val.amount);
      });
      return total.reduce(function (total, num) {
        return total + num;
      }, 0);
      },


    statusone: function () {
      var vm = this;
      var fav = vm.fa;
      return vm.filteredPeople.filter(function (data) {
        return fav === "All" || data.status === fav;
      });
    },



    statutwo: function () {
      var vm = this;
      var two = vm.fatwo;
      return vm.filteredPeople.filter(function (twodata) {
        return two === "All" || twodata.status === two;
      });
      },


    statuthree: function () {
      var vm = this;
      var three = vm.fathree;
      return vm.filteredPeople.filter(function (threedata) {
        return three === "All" || threedata.status === three;
      });
      },


    countemployeeobjarbation: function () {
      var vm = this;
      var countemp = vm.countempobjarbation;
      return vm.filteredPeople.filter(function (emp) {
        return countemp === "All" || emp.employeeId === countemp;
      });
      },



  },
});
