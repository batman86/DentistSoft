$('document').ready(function () {
    Main.Init();
});


var selector,
    Main = {
        selectors: {
            btnAdd: $('#btnAdd'),
        },
        Init: function () {

            selector = this.selectors;
            vm = this.vmPrescription;

            this.BindUiActions();
        },
        BindUiActions: function () {
            selector.btnAdd.on("click", function () {
                var _medID = $("#MedicineDropDown option:selected").val();
                var _medName = $("#MedicineDropDown option:selected").text();

                var _doseVal = $("#MedicineDropDown option:selected").data('Dose');
                var _ScaleType = $("#MedicineDropDown option:selected").data('ScaleType');
                var _Concentration = $("#MedicineDropDown option:selected").data('Concentration');
                var _SideEffectDecsription = $("#MedicineDropDown option:selected").data('SideEffectDecsription');


                var _txtDose = $('#txtDose').val();
                var _txtUnite = $('#txtUnite').val();
                var _txtFocuse = $('#txtFocuse').val();

                var innerIL = '<tr> <td><input class="medicenID" type="hidden" value="' + _medID + '" />  <label class="medicenName" > ' + _medName + '</label>  </td><td><label class="_txtDose" > ' + _txtDose + '</label> </td><td>  <label class="_txtUnite" > ' + _txtUnite + '</label>  </td>  <td><label class="_txtFocuse" > ' + _txtFocuse + '</label>  </td> <td> <input type="button" class="btnRemoveMedcFromList" value="X" /></td> </tr>';

                $(this).parent().parent().parent().find('tr:last').after(innerIL);

                vm.push(new obPrescriptionMedicine(_medID, _txtDose, _txtUnite, _txtFocuse));

            });
        },
        obPrescriptionMedicine: function (MedicineID, Dose, ScaleType, Foucse) {
            this.MedicineID = MedicineID;
            this.Dose = Dose;
            this.ScaleType = ScaleType;
            this.Foucse = Foucse;
        },
        vmPrescription: []
    }

//obPrescription: function (Notice, MedicineID, PatientID, DoctorID, Dose, AppointmentID, Medicines) {
//    this.Notice = Notice;
//    this.MedicineID = MedicineID;
//    this.PatientID = PatientID;
//    this.DoctorID = DoctorID;
//    this.Dose = Dose;
//    this.AppointmentID = AppointmentID;
//    this.Medicines = Medicines;
//},
//obMedicine: function (MedicineID, Name, SideEffectDecsription, ScaleType) {
//    this.MedicineID =MedicineID;
//    this.Name = Name;
//    this.SideEffectDecsription = SideEffectDecsription;
//    this.ScaleType = ScaleType;
//},