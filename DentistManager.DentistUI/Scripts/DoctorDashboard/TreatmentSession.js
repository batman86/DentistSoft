$('document').ready(function () {
    Main.Init();
});

var selector,
    Main = {
        selectors: {
            hidnAppointmentID: $('#AppointmentID'),
            hidnDoctorID: $('#DoctorID'),
            hidnPatientID: $('#PatientID'),
            TreatmentList: $('#TreatmentList'),
            appointmentDate: $('#appointmentDate').val(),
            btnRemoveTreatment: $('.btnRemoveTreatment'),
            btnSaveTreatments: $('#btnSaveTreatments'),
            btnAddMatrial:$('#btnAddMatrial'),
            treatmentItemID: 1,
            tempOpperationID: 0,
            tempToothNumber:0,
            
        },
        Init: function () {

           

            selector = this.selectors;
            vm = this.vmTreatmentList;
            vmMatrailList = this.vmMatrailList;
            vmMatrailWrap = this.matrailToSaveWrap;
            vmTreatmentMatrailList = this.vmTreatmentMatrailList
            ArToothSidesNumbers = this.arToothSidesNumbers;

            //Main.test('1-');

            this.getTreatmentList();
            this.loadTreatmentList();
            this.loadGraphDraw();
            this.BindUiActions();

           
        },
        BindUiActions: function () {

            selector.btnSaveTreatments.on("click", function () {

                Main.saveTreatmentToObject();
                Main.saveTreatmentToDatabase();

                $('#btnSaveTreatments').removeClass('red');

                window.location.href = window.location.href;

            });
            $(document).on('click', '.btnAddMatrial', function () {
                if (vmMatrailList.length == 0)
                {
                    Main.LoadMatrailList();
                }
                var htmlString = $.trim($(this).parent().parent().find('.matrialWrap').html());

                if (htmlString.length  == 0)
                {
                    vmTreatmentMatrailList.length = 0;

                    Main.LoadTreatmentMatrailList($(this).parent().parent().find('.TeratmentID').val());
                    var innerIL = '';
                    for (var i = 0; i < vmTreatmentMatrailList.length; i++) {
                        innerIL += '<tr class="MatrailListHolder"> <td><input class="MatrailID" type="hidden" value="' + vmTreatmentMatrailList[i].ItemID + '" />  <label id="MatrailName" > ' + vmTreatmentMatrailList[i].ItemName + '</label></td><td>  <label class="lblMatrailQuantity" > ' + vmTreatmentMatrailList[i].Quantity + '</label> </td><td> <input type="button" class="btnRemoveMatrailFromList" value="X" /> </td></tr>';
                    }

                    var drop = '<tr> <td><select class="MatrialDropDown" >';
                    for (var i = 0; i < vmMatrailList.length; i++) {
                        drop += '<option value="' + vmMatrailList[i].ItemID + '">' + vmMatrailList[i].ItemName + '</option>';
                    }
                    drop += '</select>';

                    drop += '<input class="MatrailTeratmentID" type="hidden" value="' + $(this).parent().parent().find('.TeratmentID').val() + '" /> </td>';

                    drop += '<td><input class="txtMatrailQuantity" type="text" value="" /></td>';

                    drop += '<td> <input type="button" class="btninsertMatialToList" value="Add" /></td></tr>';

                    drop += innerIL ;

                    drop += '<tr><td><input type="button" class="btnSaveMatrialList" value="Save Matrail" /></td></tr>';

                    $(this).parent().parent().find('.matrialWrap').html(drop);
                }
                else
                {
                   
                    $(this).parent().parent().find('.matrialWrap').html('');
                }

            });

            $(document).on('click', '.btninsertMatialToList', function () {

                var Quantity = $(this).parent().parent().find('.txtMatrailQuantity').val();
                var matrailName = $(this).parent().parent().find('.MatrialDropDown').find('option').filter(':selected').text();
                var matrailID = $(this).parent().parent().find('.MatrialDropDown').val();
                var check = false;

                $(this).parent().parent().parent().find('tr.MatrailListHolder').each(function () {

                    var _martailID = $(this).find('.MatrailID').val();
                     if (matrailID == _martailID)
                    {
                        var quqnt = $(this).find('.lblMatrailQuantity').text();
                        quqnt = +quqnt + +Quantity;

                        $(this).find('.lblMatrailQuantity').text(quqnt);
                        check = true;

                    }
                });
                if (check == false)
                {
                    var innerIL = '<tr class="MatrailListHolder"> <td><input class="MatrailID" type="hidden" value="' + matrailID + '" />  <label id="MatrailName" > ' + matrailName + '</label>  </td><td><label class="lblMatrailQuantity" > ' + Quantity + '</label> </td><td> <input type="button" class="btnRemoveMatrailFromList" value="X" /></td> </tr>';

                    $(this).parent().parent().parent().find('tr:last').before(innerIL);
                }
            });

            $(document).on('click', '.btnRemoveMatrailFromList', function () {
                

                var treatmentID = $(this).parent().parent().parent().find('tr:first').find('.MatrailTeratmentID').val();
                var martailID = $(this).parent().parent().find('.MatrailID').val();
                Main.RemoveMatrailOFtreatment(treatmentID, martailID);
                $(this).parent().parent().remove();
            });

            $(document).on('click', '.btnSaveMatrialList', function () {
               
                    vmMatrailWrap.vmMatrailListToSave.length = 0;

                    $(this).parent().parent().parent().children('.MatrailListHolder').each(function () {
                    var martailID = $(this).find('.MatrailID').val();
                    var quqnt = $(this).find('.lblMatrailQuantity').text();
                    vmMatrailWrap.vmMatrailListToSave.push(new Main.obMatrailListItemToSave(martailID, quqnt));
                });

                    var treatmentID = $(this).parent().parent().parent().find('tr:first').find('.MatrailTeratmentID').val();
                    
                    vmMatrailWrap.treatmentID = treatmentID;
                    Main.SaveMatrailOFtreatment();
                   
                    $(this).parent().parent().parent().parent().html('');
            });


            $(document).on('click', '.btnRemoveTreatment', function () {
                var s = $(this).parent().parent().find('td .treatmentItemID').val();
                var s2 = $(this).parent().parent().find('td .TeratmentID').val();
                
                //var s3 = $(this).parent().parent().children('.treatmentItemID').val();

                for (var i = 0; i < vm.length; i++) {
                    if (vm[i].treatmentItemID == s) {
                        vm.splice(i, 1);
                    }
                }
                if (s2 != 0) {
                    Main.RemoveTreatmentItem(s2);
                }
               
                $(this).parent().parent().remove();

                Main.loadGraphDraw();
            });
        },
        obTreatmentListItem: function (treatmentItemID, TeratmentID, Description, AppointmentDate, opperatioName, TeratmentCost, treatmentState, toothNumber, toothSideNumber, opperationColor, OpperationID) {
            this.treatmentItemID = treatmentItemID;
            this.TeratmentID = TeratmentID;
            this.Description = Description;
            this.AppointmentDate = AppointmentDate;
            this.opperatioName = opperatioName;
            this.OpperationID = OpperationID;
            this.TeratmentCost = TeratmentCost;
            this.treatmentState = treatmentState;
            this.toothNumber = toothNumber;
            this.toothSideNumber = toothSideNumber;
            this.opperationColor = opperationColor;
        },
        obMatrailListItem: function (ItemID, ItemName) {
            this.ItemID = ItemID;
            this.ItemName = ItemName;
        },
        obTreatmentMatrailListItem: function (ItemID, ItemName, Quantity) {
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.Quantity = Quantity;
        },
        obMatrailListItemToSave: function (MatrailID, Quantity) {
            this.MatrailID = MatrailID;
            this.Quantity = Quantity;
        },
        LoadMatrailList:function()
        {
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/GetMatrialList",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                success: function (result) {
                    for (var i = 0; i < result.length; i++) {
                        vmMatrailList.push(new Main.obMatrailListItem(result[i].ItemID, result[i].ItemName));
                    }
                }
            });
        },
        LoadTreatmentMatrailList: function (treatmentid) {
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/GetTreatmentMatrialList",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ treatmentID: treatmentid }),
                success: function (result) {
                    for (var i = 0; i < result.length; i++) {
                        vmTreatmentMatrailList.push(new Main.obTreatmentMatrailListItem(result[i].ItemID, result[i].ItemName, result[i].Quantity));
                    }
                }
            });
        },
        SaveMatrailOFtreatment: function (TreatmentID) {
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/matrailTreatmentSave",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ matrailToSave: vmMatrailWrap }),
                success: function () {
                    alert('Materials Has Been Saved');
                }
            });
        },
        RemoveMatrailOFtreatment: function (TreatmentID, matrailID) {
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/removeTreatmentMatrail",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ matrailID: matrailID, treatmentID: TreatmentID }),
                success: function () {
                    alert('Materials Has Been Removed');
                }
            });
        },
        getTreatmentList: function () {
            var patientID = selector.hidnPatientID.val();
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/GetTreatmentListByPatientID",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ patientID: patientID }),
                success: function (result) {
                    for (var i = 0; i < result.length; i++) {
                        selector.treatmentItemID = selector.treatmentItemID + 1;
                        var date=new Date(parseInt(result[i].AppointmentDate.substr(6)));
                        var formatted = date.getFullYear() + "-" +  ("0" + (date.getMonth() + 1)).slice(-2) + "-" +  ("0" + date.getDate()).slice(-2) ;    
                        vm.push(new Main.obTreatmentListItem(selector.treatmentItemID, result[i].TeratmentID, result[i].Description, formatted, result[i].opperatioName, result[i].TeratmentCost, result[i].treatmentState, result[i].toothNumber, result[i].toothSideNumber, result[i].opperationColor, result[i].OpperationID));
                    }
                }
            });

        },
        RemoveTreatmentItem: function (TreatmentID) {
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/RemoveTreatmentItem",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ treatmentID: TreatmentID }),
                success: function () {
                    alert('Treatment Has Been Removed');
                }
            });
        },
        loadTreatmentList: function () {
            for (var i = 0; i < vm.length; i++) {
                $('#TreatmentList').append('<tr>  <td>  <input class="treatmentItemID" type="hidden" value="' + Main.vmTreatmentList[i].treatmentItemID + '" />  <input class="OpperationID" type="hidden" value="' + Main.vmTreatmentList[i].OpperationID + '" /> <input class="TeratmentID" type="hidden" value="' + Main.vmTreatmentList[i].TeratmentID + '" /> <label id="toothSideNumber" > ' + Main.vmTreatmentList[i].toothSideNumber + '</label></td> <td> <label id="toothNumber" > ' + Main.vmTreatmentList[i].toothNumber + '</label></td>  <td> <label id="opperatioName" > ' + Main.vmTreatmentList[i].opperatioName + '</label></td>  <td><label id="AppointmentDate" > ' + Main.vmTreatmentList[i].AppointmentDate + '</label></td> <td> <input class="Description" type="text" value="' + Main.vmTreatmentList[i].Description + '" /> </td> <td>  <input class="TeratmentCost"  type="text" value="' + Main.vmTreatmentList[i].TeratmentCost + '" /></td>  <td> <input type="button" class="btnRemoveTreatment" value="X" /></td> <td> <input type="button" class="btnAddMatrial" value="Matrial" /></td> <td> <table class="matrialWrap "> </table></td> </tr>');
            }
        },
        saveTreatmentToObject: function () {
            $('#TreatmentList tr').each(function () {
                var s = $(this).find('.treatmentItemID').val();
                var description = $(this).find('.Description').val();
                var treatmentCost = $(this).find('.TeratmentCost').val();
                for (var i = 0; i < vm.length; i++) {
                    if (vm[i].treatmentItemID == s) {
                        vm[i].Description = description;
                        vm[i].TeratmentCost = treatmentCost;
                    }
                }
            });
        },
        saveTreatmentToDatabase: function () {
            var appointID=$('#AppointmentID').val();
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/TreatmentSave",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ treatmentList: vm, appointmentID: appointID }),
                success: function () {
                    alert('Treatments Has Been Saved');
                }
            });
        },
        loadGraphDraw: function () {

            stage = new Kinetic.Stage({
                container: 'container',
                width: 1150,
                height: 220
            });
            layer = new Kinetic.Layer();

            drawCircle = function (X, Y, Radius, FillColor, StrokeColor, StrokeWidth, ID) {
                var circle = new Kinetic.Circle({
                    x: X,
                    y: Y,
                    radius: Radius,
                    fill: FillColor,
                    stroke: StrokeColor,
                    strokeWidth: StrokeWidth,
                    id: ID
                });
                return circle;
            }
            drawWadg = function (X, Y, Radius, Angle, FillColor, StrokeColor, StrokeWidth, Rotation, ID) {
                var wedge = new Kinetic.Wedge({
                    x: X,
                    y: Y,
                    radius: Radius,
                    angle: Angle,
                    fill: FillColor,
                    stroke: StrokeColor,
                    strokeWidth: StrokeWidth,
                    rotation: Rotation,
                    id: ID
                });
                return wedge;
            }
            drawText = function (X, Y, Text, FontSize, FontFamily, FillColor) {
                var myText = new Kinetic.Text({
                    x: X,
                    y: Y,
                    text: Text,
                    fontSize: FontSize,
                    fontFamily: FontFamily,
                    fill: FillColor
                })
                return myText;
            }

            var xPosation = 50;
            var yPosation = 50;

            var wedge1color1;
            var wedge1color2;
            var wedge1color3;
            var wedge1color4;
            var wedge1color5;
            var count = 0;
            var courtNum = 1;
            var courtCounter = 9;
            var toothID = '';

            for (var i = 1; i < 33; i++) {

                wedge1color1 = '#ffffff';
                wedge1color2 = '#ffffff';
                wedge1color3 = '#ffffff';
                wedge1color4 = '#ffffff';
                wedge1color5 = '#ffffff';

                if (courtNum == 2 || courtNum == 4)
                    courtCounter++;
                else
                    courtCounter--;
                if (courtCounter > 8 || courtCounter < 1)
                    courtNum++;
                if (courtCounter == 0)
                    courtCounter = 1;
                if (courtCounter == 9)
                    courtCounter = 8;

                //alert('courCount ' + courtCounter + 'Num ' + courtNum);

                toothID = courtNum + '*' + courtCounter;

                if (count < vm.length) {
                for (var k = 0; k < vm.length; k++) {
                   
                    Main.test(vm[k].toothSideNumber);

                    if (vm[k].toothNumber == toothID) {

                        for (var j = 0; j < ArToothSidesNumbers.length; j++) {

                                if (ArToothSidesNumbers[j] == "1"){
                                    wedge1color1 = vm[k].opperationColor;
                                    continue;
                                }
                                else if (ArToothSidesNumbers[j] == "2"){
                                    wedge1color2 = vm[k].opperationColor;
                                    continue;
                                }
                                else if (ArToothSidesNumbers[j] == "3"){
                                    wedge1color3 = vm[k].opperationColor;
                                    continue;
                                }
                                else if (ArToothSidesNumbers[j] == "4"){
                                    wedge1color4 = vm[k].opperationColor;
                                    continue;
                                }
                                else if (ArToothSidesNumbers[j] == "5") {
                                    wedge1color5 = vm[k].opperationColor;
                                    continue;
                                }
                            }
                            count++;
                        }
                    }
                }

                var wedge1 = drawWadg(xPosation, yPosation, 30, 90, wedge1color1, 'black', 2, 225, toothID + "-1");
                var wedge2 = drawWadg(xPosation, yPosation, 30, 90, wedge1color2, 'black', 2, 315, toothID + "-2");
                var wedge3 = drawWadg(xPosation, yPosation, 30, 90, wedge1color3, 'black', 2, 45, toothID + "-3");
                var wedge4 = drawWadg(xPosation, yPosation, 30, 90, wedge1color4, 'black', 2, 135, toothID + "-4");
                var circle1 = drawCircle(xPosation, yPosation, 12, wedge1color5, 'black', 2, toothID + "-5");
                var text1 = drawText(xPosation - 5, yPosation + 40, toothID, 14, 'arial', 'black');

                wedge1.on("click", Main.clickEventMsg)
                wedge2.on("click", Main.clickEventMsg);
                wedge3.on("click", Main.clickEventMsg);
                wedge4.on("click", Main.clickEventMsg);
                circle1.on("click", Main.clickEventMsg);

                layer.add(wedge1);
                layer.add(wedge2);
                layer.add(wedge3);
                layer.add(wedge4);
                layer.add(circle1);
                layer.add(text1);

                xPosation += 70;

                if (i == 16) {
                    yPosation += 100;
                    xPosation = 50;
                }


                
            }
            stage.add(layer);
        },
        clickEventMsg: function () {
            var tempOpperationID= selector.tempOpperationID;
            var tempToothNumber= selector.tempToothNumber;

            var selectedValue = $('input[name=SelectedOpperation]:radio:checked', '#OpperationForm').val();
            if (typeof selectedValue === 'undefined') {
                alert('Please Select Opperation');
                return;
            }

            var oppName = $('input[name=SelectedOpperation]:radio:checked', '#OpperationForm').data('opperationname');
            var oppColor = $('input[name=SelectedOpperation]:radio:checked', '#OpperationForm').data('fillcolor');

            var index = this.attrs.id.indexOf('-');
            var toothNumber = this.attrs.id.substr(0, index);
            var graphtoothSideNumber = this.attrs.id.substr(index+1 , this.attrs.id.length - 1);
            var toothSideNumber = graphtoothSideNumber + '+';

            if (tempOpperationID == selectedValue && tempToothNumber == toothNumber)
            {
                for (var i = 0; i < vm.length; i++) {
                    if(vm[i].treatmentItemID ==  selector.treatmentItemID && vm[i].OpperationID ==tempOpperationID &&  vm[i].toothNumber == tempToothNumber)
                    {
                        vm[i].toothSideNumber = vm[i].toothSideNumber + toothSideNumber;
                        $('#TreatmentList tr:last').find('#toothSideNumber').text(vm[i].toothSideNumber);
                      
                    }
                }
            }
            else
            {
                selector.treatmentItemID = selector.treatmentItemID + 1;
                vm.push(new Main.obTreatmentListItem(selector.treatmentItemID, 0, '', selector.appointmentDate, oppName, '', 'State : in progress', toothNumber, toothSideNumber, oppColor, selectedValue));
                $('#TreatmentList').append('<tr><td> <input class="treatmentItemID" type="hidden" value="' + selector.treatmentItemID + '" /> <input class="OpperationID" type="hidden" value="' + selectedValue + '" />  <input class="TeratmentID" type="hidden" value="' + 0 + '" /> <label id="toothSideNumber" > ' + toothSideNumber + '</label></td> <td><label id="toothNumber"> ' + toothNumber + '</label></td><td>   <label id="opperatioName" > ' + oppName + '</label></td><td>  <label id="AppointmentDate" > ' + selector.appointmentDate + '</label></td><td> <input class="Description" type="text" value="" /> </td><td>  <input class="TeratmentCost" type="text" value="" /></td><td> <input type="button" class="btnRemoveTreatment" value="X" /></td> </tr>');
                
                selector.tempOpperationID = selectedValue;
                selector.tempToothNumber = toothNumber;
            }
          

            Main.loadGraphDraw();
            $('#btnSaveTreatments').addClass('red');
            // 
        },
        vmTreatmentList: [],
        arToothSidesNumbers: [],
        vmMatrailList: [],
        vmTreatmentMatrailList:[],
        matrailToSaveWrap: {
            treatmentID:0,
            vmMatrailListToSave: []
        },
        test: function (toothSide) {

            ArToothSidesNumbers.length = 0;
            var index;
            var toothSideNumber;

            while (toothSide.length > 0) {
                index = toothSide.indexOf('+');
                toothSideNumber = toothSide.substr(0, index);
                ArToothSidesNumbers.push(toothSideNumber);
                toothSide = toothSide.substr(index + 1, toothSide.length);
            }
        }
       
    };


