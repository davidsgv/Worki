<?php include('header.php'); ?>    
<?php include('session.php'); ?>    
<body>
	<br>
	<br>
	<br>
	<br>
	<div class="container"><h1 class="text-center">Editar perfil</h1></div>
	<hr>
	<br>
	<br>
	<?php include('navbar.php'); ?>
			<div id="masthead">  
				<div class="container">
					<div class="row">
                        <div class="col-md-2">
							<img class="img-circle" src="<?php echo $image; ?>" height="170" width="170"/>
							<hr>
							<?php
								$query = $conn->query("select * from members where member_id = '$session_id'");
								$row = $query->fetch();
								$id = $row['member_id'];
							?>
							<p class="lead text-center" style="color: black;"><?php echo $row['firstname']." ".$row['lastname']; ?></p>
    					</div>
						<div class="col-md-6 col-md-offset-2">
						<?php
							$query = $conn->query("select * from members where member_id = '$session_id'");
							$row = $query->fetch();
							$id = $row['member_id'];
						?>
						<form method="post" action="save_edit.php">
								<input type="hidden" name="member_id" value="<?php echo $id; ?>">
								Usuario:<br><br>
								<input class="form-control" type="text" name="username" value="<?php echo $row['username']; ?>">
							<hr>
								Nombre:<br><br><input class="form-control" type="text" name="firstname" value="<?php echo $row['firstname']; ?>">
							<hr>
								Apellido:<br><br><input class="form-control" type="text" name="lastname" value="<?php echo $row['lastname']; ?>">
							<hr>
								Fecha de Nacimiento:<br><br><input class="form-control" name="birthdate" type="text" value="<?php echo $row['birthdate']; ?>">
							<hr>
								Dirección:<br><br><input class="form-control" name="address" type="text" value="<?php echo $row['address']; ?>">
							<hr>
								Estado:<br><br><input class="form-control" name="status" type="text" value="<?php echo $row['status']; ?>">
							<hr>
								Móvil:<br><br><input class="form-control" name="mobile" type="text" value="<?php echo $row['mobile']; ?>">
								<br>
							<button name="save" class="btn edit">Guardar cambios</button>
                        </form>
						<br>
						<br>
					</div>
				</div>
			</div>
</body>
