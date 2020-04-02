$(document).ready(function() {
  // Add checkboxes to the MarkCompleted method
  $(".done-checkbox").on("click", function(e) {
    markCompleted(e.target);
  });
});

function markCompleted(checkbox) {
  // Mark checkbox as disabled
  checkbox.disabled = true;

  // Update the row styling
  var row = checkbox.closest("tr");
  $(row).addClass("done");

  // Call the form submit
  var form = checkbox.closest("form");
  form.submit();
}
