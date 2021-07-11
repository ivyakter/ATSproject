var app = new Vue({
    el: "#view",
    data: {

  EmpgggList: [
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
  Veiwitemlist: [],
      pid: "",
    },
  
    methods: {
        viweproduct(id) {           
            var Veiwitem = this.EmpgggList.find((k) => k.id == id);
            this.Veiwitemlist=Veiwitem;
             console.log(this.Veiwitemlist);
      },     
    },
  
  
    mounted() {
        const urlParams = new URLSearchParams(window.location.search);
        const myParam = urlParams.get("id");
        this.pid = myParam;
        this.viweproduct(this.pid);
      
    },
  });
  