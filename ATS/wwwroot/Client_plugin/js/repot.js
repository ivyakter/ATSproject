var app = new Vue({
    el: "#repot",
    data: {
     
  categoty: [
    { id: 1, name: "FAPAD" },
    { id: 2, name: "LAD" },
    { id: 3, name: "Internal" },
  ],
  
  
  mainProjectList: [
    { id: 1, name: "HPNSP" },
    { id: 2, name: "FPSD " },
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
      employeeId: "ATS0001",
      name: "Ahammed Ali",
      designation:"Divisional officer",
      posting:"Savar Upazila",
      years:"2020",
      amount: "25,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.25,99,00,000.00 procurement",
      date: "2020-07-10",
      division: "Dhaka",
      district: "Dhaka",
      upazila: "Mohamoddpur Upazila",
      projectId: 1,
      projectname:"HPNSP",
      categotyId: 1,
      categotyname:"FAPAD",
      status: 1,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
    },
  {
      id: 2,
      employeeId:"ATS0002",
      name: "Shakil KHAN",
      designation:"Divisional officer",
      posting:"Savar Upazila",
      years:"2020",
      amount: "20,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.30,99,00,000.00 procurement",
      date: "2019-17-10",
      division: "Dhaka",
      district: "Dhaka",
      upazila: "Savar Upazila",
      projectId: 2,
      projectname:"FPSD",
      categotyId: 1,
      categotyname:"FAPAD",
      status: 2,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
    },
  
  {
  id: 3,
      employeeId:"ATS0003",
      name: "Zubayer Parvez",
      designation:"Divisional officer",
      posting:"Dhaka",
      years:"2017",
      amount: "15,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.20,99,00,000.00 procurement",
      date: "2018-17-10",
      division: "Khulna",
      district: "Meherpur",
      upazila: "Meherpur Upazila",
      projectId: 3,
      projectname:"USAID",
      categotyId: 1,
      categotyname:"FAPAD",
      status: 3,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 4,
      employeeId:"ATS0004",
      name: "Joy Molla",
      designation:"District officer",
      posting:"Kushtia Upazila",
      years:"2020",
      amount: "40,90,00,000.00",
      titel:"Irregular expenditure amounting to TK.40,90,00,000.00 procurement",
      date: "2018-15-12",
      division: "Dhaka",
      district: "Madaripur",
      upazila: "Madaripur Upazila",
      projectId: 4,
      projectname:"BSAID",
      categotyId: 2,
      categotyname:"LAD",
      status: 2,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
      id: 5,
      employeeId:"ATS0005",
      name: "Sobuj Ali",
      designation:"Divisional officer",
      posting:"Savar Upazila",
      years:"2016",
      amount: "10,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.10,99,00,000.00 procurement",
      date: "2020-17-10",
      division: "Barishal",
      district: "Bhola",
      upazila: "Bhola Upazila",
      projectId: 1,
      projectname:"HPNSP",
      categotyId: 2,
      categotyname:"LAD",
      status: 1,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 6,
      employeeId:"ATS0006",
      name: "Jisan Khan",
      designation:"Divisional officer",
      posting:"Chadpur Upazila",
      years:"2017",
      amount: "50,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.50,99,00,000.00 procurement",
      date: "2018-10-12",
      division: "Chittagong",
      district: "Chadpur",
      upazila: "Chadpur Upazila",
      projectId: 1,
      projectname:"HPNSP",
      categotyId: 3,
      categotyname:"Internal",
      status: 2,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 7,
      employeeId:"ATS0007",
      name: "Alve Ahamed",
      designation:"DD",
      posting:"Panba Upazila",
      years:"2018",
      amount: "40,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.40,99,00,000.00 procurement",
      date: "2018-10-08",
      division: "Chittagong",
      district: "Chadpur",
      upazila: "Chadpur Upazila",
      projectId: 4,
      projectname:"BSAID",
      categotyId: 2,
      categotyname:"LAD",
      status: 3,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 8,
      employeeId:"ATS0008",
      name: "Polok Ahamed",
      designation:"DD",
      posting:"Monshiganj",
      years:"2019",
      amount: "10,90,00,000.00",
      titel:"Irregular expenditure amounting to TK.10,99,00,000.00 procurement",
      date: "2019-10-10",
      division: "Dhaka",
      district: "Monshiganj",
      upazila: "Monshiganj Upazila",
      projectId: 5,
      projectname:"fP Main Scheem",
      categotyId: 3,
      categotyname:"Internal",
      status: 2,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 9,
      employeeId:"ATS0009",
      name: "Rabbani Ahamed",
      designation:"DG",
      posting:"Dhaka",
      years:"2017",
      amount: "20,90,00,000.00",
      titel:"Irregular expenditure amounting to TK.20,99,00,000.00 procurement",     
      date: "2019-10-10",
      division: "Dhaka",
      district: "Dhaka",
      upazila: "Narayanganj Upazila",
      projectId: 3,
      projectname:"USAID",
      categotyId: 3,
      categotyname:"fAPAD",
      status: 1,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 10,
      employeeId:"ATS0010",
      name: "Shofiq Ahamed",
      designation:"DD",
      posting:"Dhaka",
      years:"2017",
      amount: "20,90,00,000.00",
      titel:"Irregular expenditure amounting to TK.20,99,00,000.00 procurement",     
      date: "2018-10-10",
      division: "Khulna",
      district: "Battaghata",
      upazila: "Battaghata",
      projectId: 3,
      projectname:"FPSD",
      categotyId: 3,
      categotyname:"fAPAD",
      status: 1,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  ],
      mm: [],
      Category: "",
      Projec: "",
      Years: "",
      search: "",
      Division:"",
      startDate: null,
      endDate: null,
      Veiwitemlist: [],
      audit:"Select Aduit",
      Projecselect:"Select project",
      Yearsselect:"Select Years",
      DivisionSelect:"Select Division",
      shows:false,
      showsbutton:false,
      showstext:true,
    },
  
    methods: {
      view(id) {
        var Veiwitem = this.EmpList.find((k) => k.id === id);
        this.Veiwitemlist = Veiwitem;
      },
      filtergg() {
        this.Category = "All";
        this.Projec = "All";
        this.Years = "All";
        this.Division="All";
        this.Projecselect="Select project";
        this.Yearsselect="Select Years";
        this.DivisionSelect="Select Division";
        this.audit="All";
        this.shows=true;
        this.showsbutton=true;
        this.showstext=false;
      },
      years(name){
        this.Years =name;
        this.Yearsselect=name;
        this.shows=true;
        this.showsbutton=true;
        this.showstext=false;
      },
      divisionfilter(g){
        this.Division=g;
        this.DivisionSelect=g;
        this.shows=true;
        this.showsbutton=true;
        this.showstext=false;
      },
      filterg(id) {
        
        this.Category = id;
        this.audit=id;
        this.shows=true;
        this.showsbutton=true;
        this.showstext=false;
      },
      filterproject(id) {
        this.Projec = id;
        this.Projecselect = id;
        this.shows=true;
        this.showsbutton=true;
        this.showstext=false;
      },
      ExportPdf: function () {

        var List = [
        { name: 'Name',dataKey: "name",header: "Name"},
        {categotyname: 'categotyname',dataKey: "categotyname",header: "Category Name"},
        {project: 'projectname',dataKey: "projectname",header: "project"},
        {titel: 'Titel',dataKey: "titel",header: "Titel"},
        ];
        var doc = new jsPDF(); 
        
        doc.autoTable(List,this.filteredPeople);
        doc.save('ATS.pdf');
        
        }, 
        FlitterProductByCategory(){
          this.shows=true;
          this.showsbutton=true;
          this.showstext=false;
        },
        FlitterProductByCategorya(){
          this.shows=true;
          this.showsbutton=true;
          this.showstext=false;
        },
        FlitterProductByCategoryb(){
          this.shows=true;
          this.showsbutton=true;
          this.showstext=false;
        }
    },
  
  
    mounted() {
        this.Category = "All";
        this.Projec = "All";
        this.Years ="All";
        this.Division ="All";
    },
    computed: {
      filteredPeople: function () {
        var vm = this;
       var years=vm.Years
       var division=vm.Division
       
        var project = vm.Projec;
        var category = vm.Category;
        var startDate = vm.startDate;
        var endDate = vm.endDate;
  
        if (category === "All" && project === "All" && years=== "All" && division==="All") {
          return vm.EmpList.filter(function (item) {
            return item.employeeId.toLowerCase().indexOf(vm.search.toLowerCase()) >= 0;
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
        }
        
        
        else {
          return vm.EmpList.filter(function (productList) {
              
            return ( category === "All" || productList.categotyname === category) && 
            (project === "All" || productList.projectname === project) &&  
            (years=== "All" || productList.years ===years)&&
            (division=== "All" || productList.division ===division) ;
  
          
          })
    
            .filter(function (item) {
              return (
                item.employeeId.toLowerCase().indexOf(vm.search.toLowerCase()) >= 0
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
    },
  });
  