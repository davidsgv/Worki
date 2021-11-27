<?php
include('dbcon.php');
$member_id = $_POST['member_id'];
$username = $_POST['username'];
$firstname = $_POST['firstname'];
$lastname = $_POST['lastname'];
$address = $_POST['address'];
$birthdate = $_POST['birthdate'];
$mobile = $_POST['mobile'];
$status = $_POST['status'];



$conn->query("update members set username = '$username',firstname = '$firstname',lastname='$lastname',address='$address',
birthdate='$birthdate',mobile='$mobile',status='$status' where member_id = '$member_id'");

?>
<script>
	window.location = 'edit_profile.php<?php echo '?id='.$member_id; ?>';
</script>