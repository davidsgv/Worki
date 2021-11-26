<?php include('header.php'); ?>    
<?php include('session.php'); ?>    
<body>
	<?php include('navbar.php'); ?>

</body>
<br>
<br>
<br>
<br>
<br>
<!-- Jumbotron -->
<div class="container">
	<div class="col-md-8 col-md-offset-2" style="color: black; border: 2px solid #000000; border-radius: 30px;">
		<h1 class="text-center">Actualiza tu imagen</h1><br>
		<div class="col-md-4">
          <img class="img-circle" src="<?php echo $image; ?>" height="200" width="200">
		  <?php
			$query = $conn->query("select * from members where member_id = '$session_id'");
			$row = $query->fetch();
			$id = $row['member_id'];
		  ?>
		  
		  <p class="lead text-center" style="color: black;"><?php echo $row['firstname']." ".$row['lastname']; ?></p>
        </div>
		<div class="col-md-8">
		  <br>
		  <br>
		  <div id="masthead">  
		    <div class="container">
              <div class="col-md-5">
	            <form  id="upload_image"  class="form-horizontal" method="POST" enctype="multipart/form-data">
	              <div class="control-group">
	        	  	<label class="control-label" for="input01">Imagen: </label>
          			<div class="controls">
		        	  	<input type="file" name="image" class="font" required>
		          	</div>
	              </div>
				  <br>
	              <div class="control-group">
			        <div class="controls">
						<button class="btn btn" type="submit" name="submit" style="color: black; border: 2px solid #000000; border-radius: 30px;">Cambiar Imagen</button>
	          		    <br>
					</div>
	              </div>			
            	</form>
				<?php
				if (isset($_POST['submit'])) {
			
				$image = addslashes(file_get_contents($_FILES['image']['tmp_name']));
				$image_name = addslashes($_FILES['image']['name']);
				$image_size = getimagesize($_FILES['image']['tmp_name']);
			
				move_uploaded_file($_FILES["image"]["tmp_name"], "images/" . $_FILES["image"]["name"]);
				$location = "images/" . $_FILES["image"]["name"];
				$conn->query("update members set image = '$location' where member_id  = '$session_id' ");
				?>
          		<script>	window.location = 'home.php'; </script>
				<?php
				}
				?>
              </div>
		    </div><!-- /cont -->
          </div>
        </div>
	</div>
</div>