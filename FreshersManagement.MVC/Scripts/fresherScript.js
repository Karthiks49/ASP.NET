$(function () {

    $('#updatePopup').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget)
        var id = button.data('id')

        $.ajax({
            url: "/Fresher/Fresher/Edit/" + id,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $('#id').val(result.id);
                $('#name').val(result.name);
                $('#mobile-number').val(result.mobileNumber);
                $('#date-of-birth').val(result.dateOfBirth);
                $('#qualification').val(result.qualification);
                $('#address').val(result.address);
                checkValidationAndSaveForm();
            },
            error: function () {
                alert("Unexcepted Error!!!");
            }
        });
    })

    function checkValidationAndSaveForm() {
        $("#myForm").validate({
            errorClass: 'errors',
            rules: {
                Id: "required",
                Name: "required",
                MobileNumber: {
                    required: true,
                    minlength: 10,
                    maxlength: 10,
                },
                DateOfBirth: "required",
                Qualification: "required",
                Address: "required"
            },
            messages: {
                Id: {
                    required: "Please enter valid Id"
                },
                Name: {
                    required: "Please enter name"
                },
                MobileNumber: {
                    required: "Please enter mobileNumber",
                    maxlength: "Invalid mobile number",
                    minlength: "Invalid mobile number"
                },
                DateOfBirth: {
                    required: "Please enter dateOfBirth"
                },
                Address: {
                    required: "Please enter address"
                },
                Qualification: {
                    required: "Please enter qualification"
                }
            },
            submitHandler: function () {
                var updatedData = $('#myForm').serialize();

                $.ajax({
                    url: "/Fresher/Fresher/Edit",
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: updatedData,
                    success: function (result) {
                        if ('1' == result) {
                            $('#updatePopup').hide();
                            window.location.replace(window.location.href)

                        } else {
                            alert("Update failed");
                        }
                    },
                    error: function () {
                        alert("Unexcepted Error!!!");
                    }
                });
            }
        });
    }
});