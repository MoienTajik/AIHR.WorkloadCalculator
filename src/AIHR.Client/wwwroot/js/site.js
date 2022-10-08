var today = new Date();
var tomorrow = new Date();
tomorrow.setDate(today.getDate() + 1);

$('#start-date').attr('min', today.toISOString().split('T')[0]);
$('#start-date').attr('value', today.toISOString().split('T')[0]);
$('#end-date').attr('min', tomorrow.toISOString().split('T')[0]);
$('#end-date').attr('value', tomorrow.toISOString().split('T')[0]);


var checkBoxes = $('.courses-checkbox');
checkBoxes.change(function () {
    $('#calculate-btn').prop('disabled', checkBoxes.filter(':checked').length < 1);
});

checkBoxes.change();


 $(function() {
     var studentId = $("#SelectedStudentId").val();
     $("#study-plan").load(`/Course/GetStudentStudyPlanDetails?studentId=${studentId}`);
     $("#usage-history").load(`/Course/GetStudentUsageHistories?studentId=${studentId}`);
 });
        
 $('#SelectedStudentId').change(function(e) {
     var studentId = $("#SelectedStudentId").val();
     $("#study-plan").load(`/Course/GetStudentStudyPlanDetails?studentId=${studentId}`);
     $("#usage-history").load(`/Course/GetStudentUsageHistories?studentId=${studentId}`);
 });
 
 function deleteStudyPlan(id) {
     $.ajax({
         url: `/Course/RemoveStudyPlan/${id}`,
         type: 'DELETE',
         success: function(result) {
             $(`#study-plan-${id}`).remove();
         }
     });
 }