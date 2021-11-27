<?php include('header.php'); ?>    
<?php include('session.php'); ?>    
<body>
<?php include('navbar.php'); ?>
<br>
<br>
<br>
<br>

<div class="container">
  <div class="page-header">
    <h1>Tus Amigos</h1>
  </div>
</div>


<div class="container" style="color: black; border: 2px solid #000000; border-radius: 30px;">
  <div class="row">
    <div class="col-md-12"> 
      <div class="">
        <div class="">
          <!--/stories-->
            <div class="row">    
            <br>
				<?php
				$query = $conn->query("select members.member_id , members.firstname , members.lastname , members.image , friends.friends_id   from members  , friends
				where friends.my_friend_id = '$session_id' and members.member_id = friends.my_id
				OR friends.my_id = '$session_id' and members.member_id = friends.my_friend_id
				");
				while($row = $query->fetch()){
				$friend_name = $row['firstname']." ".$row['lastname'];
				$friend_image = $row['image'];
				$id = $row['friends_id'];
				?>
				<div class="row">    
           		<div class="col-md-2 text-center">
            		<img  src="<?php echo $friend_image; ?>" style="width:130px; height:130px;" class="img-circle"></a>
          		</div>
				  <br>
				  <br>
				  <br>
				<div class="col-md-9">
					<div class="pull-right"><a href="delete_friend.php<?php echo '?id='.$id; ?>" class="btn btn" style="color: red; border: 2px solid red; border-radius: 30px;"> Eliminar amigo </a></div>
					<div class="alert"><?php echo $friend_name; ?></div>
				</div>
            </div><hr>
			<?php } ?>		
        </div>
    </div>
</div>