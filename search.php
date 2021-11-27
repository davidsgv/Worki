<?php include('header.php'); ?>    
<?php include('session.php'); ?>    
<?php $search = $_POST['search']; ?>
<body>
<?php include('navbar.php'); ?>
<br>
<br>
<br>
<br>
<br>
<br>
<br>		
<div class="container" style="color: black; border: 2px solid black; border-radius: 30px;">
  <div class="row">
	<h1 class="text-center">Personas en Worki</h1>
    <div class="col-md-12"> 
      <div class="panel">
        <div class="panel-body">
          <div class="row">    
            <br>
	        <?php
				$query = $conn->query("select  * from members where firstname LIKE '%$search%' or lastname  LIKE '%$search%'");
				$count = $query->rowcount();
				if ($count > 0){ 
				while($row = $query->fetch()){
				$posted_by = $row['firstname']." ".$row['lastname'];
				$posted_image = $row['image'];
				$friend_id = $row['member_id'];
			?>
            <div class="col-md-2 col-sm-3 text-center">
             	<img  src="<?php echo $posted_image; ?>" style="width:100px;height:100px" class="img-circle"></a>
            </div>
            <div class="col-md-10 col-sm-9">
             	<div class="alert"><?php echo $posted_by; ?></div>
             		<div class="row">
                		<div class="col-xs-9">
							<form method="post" action="add_friend.php">
                                <div class="col-xs-3">
									<input type="hidden" name="my_friend_id" value="<?php echo $friend_id; ?>">
									<?php 
										$query1 = $conn->query("select * from friends where my_friend_id = '$friend_id'");
										$count1 = $query1->rowcount();
										if ($count1 > 0){ echo 'All Ready Friend'; }else{
									?>	
									<button  class="btn btn" style="color: black; border: 2px solid red; border-radius: 30px;"> Añadir amigo</button>
									<?php } ?>
								</div>
							</form>
            			</div>
					</div>
                   <br><br>
            </div>
	        <?php } }else{ ?> &nbsp;&nbsp;&nbsp;&nbsp; No existe, busca de nuevo  <?php } ?>		
          </div>
        </div>
      </div>
   	</div><!--/col-12-->
  </div>
</div>

</body>
</html>