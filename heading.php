<div class="col-md-6 col-md-offset-4">
    <img class="img-circle" src="<?php echo $image; ?>" height="350" width="350"/>
</div>
<br>
<div class="col-md-12">
	<?php
		$query = $conn->query("select * from members where member_id = '$session_id'");
		$row = $query->fetch();
		$id = $row['member_id'];
	?>
	<p class="lead text-center" style="color: black;"><?php echo $row['firstname']." ".$row['lastname']; ?></p>
	<p class="text-center" style="color: black;"><?php echo $row['gender']; ?></p>
</div>
<br>
<div class="col-md-12 text-center">
  <br>
  <a class="btn btn" style="color: black; border: 2px solid #000000; border-radius: 30px;" href="cambioImagen.php"> Cambiar Imagen </a>
  <a class="btn btn" style="color: black; border: 2px solid #000000; border-radius: 30px;" href="message.php"> ver mensajes </a>
  <a class="btn btn" style="color: black; border: 2px solid #000000; border-radius: 30px;" href="edit_profile.php"> Editar perfil </a>
  <hr>
</div>

<div class="container">
    <div class="col-md-12">
		<h1>Información Personal</h1>
		<br>
		<div class="col-md-5">
			<?php
			$query = $conn->query("select * from members where member_id = '$session_id'");
			$row = $query->fetch();
			$id = $row['member_id'];
			?>
			<p>Nombre: <?php echo $row['firstname']." ".$row['lastname']; ?></p>
			<hr>
			<p>Dirección: <?php echo $row['address']; ?></p>
			<hr>
			<p>Género: <?php echo $row['gender']; ?></p>
		</div>
		<div class="col-md-5 col-md-offset-2">
			<p>Fecha de Nacimiento: <?php echo $row['birthdate']; ?></p>
			<hr>
			<p>Número de Contacto: <?php echo $row['mobile']; ?></p>
			<hr>
			<p>Estado: <?php echo $row['status']; ?></p>
		</div>
	</div>
</div>
<hr>

<br>
<div class="container">
  <div class="row">  
    <div class="col-md-12">    
      <div>
        <div class="panel-body">          
		    <h2>Mis Fotos</h2>
			<div class="pull-right">
				<form id="photos" method="POST" enctype="multipart/form-data">
				  <label class="control-label" for="input01">Imagen:</label>
			      <input type="file" name="image" class="font" required>
				  <br>
				  <button class="btn btn" type="submit" name="submit" style="color: black; border: 2px solid #000000; border-radius: 30px;">Subir Imagen</button>
				</form>
				<?php 
					if (isset($_POST['submit'])) {
					$image = addslashes(file_get_contents($_FILES['image']['tmp_name']));
					$image_name = addslashes($_FILES['image']['name']);
					$image_size = getimagesize($_FILES['image']['tmp_name']);
			
					move_uploaded_file($_FILES["image"]["tmp_name"], "upload/" . $_FILES["image"]["name"]);
					$location = "upload/" . $_FILES["image"]["name"];
					$conn->query("insert into photos (location,member_id) values ('$location','$session_id')");
				?>
				<script> window.location = 'home.php';</script>
				<?php
				}
				?>
			</div>
			<div>
				<div class="row">
					<?php
						$query = $conn->query("select * from photos where member_id='$session_id'");
						while($row = $query->fetch()){
						$id = $row['photos_id'];
					?>
					<div class="col-md-8 text-center">
						<img class="img-responsive" src="<?php echo $row['location']; ?>" >
						<hr>
						<a class="btn btn" style="color: red; border: 2px solid red; border-radius: 30px;" href="delete_photos.php<?php echo '?id='.$id; ?>">Eliminar</a>
					</div>
					<?php } ?>
				</div>
			</div>
        </div>
      </div>                                        
   	</div><!--/col-12-->
	<hr>
  </div>
</div>
