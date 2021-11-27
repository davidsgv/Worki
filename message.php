<?php include('header.php'); ?>    
<?php include('session.php'); ?>    
    <body>
	<?php include('navbar.php'); ?>
<br>
<br>
<br>
<br>
<div class="container" style="color: black; border: 2px solid #000000; border-radius: 30px;">
  <div class="page-header">
    <h1 class="text-center">Mensajes</h1>
  </div>
  <div class="row">
    <div class="col-md-12"> 
      <div class="panel">
        <div class="panel-body">
          <div class="row">    
            <br>
            <div class="col-md-6 col-sm-3 text-center">
				<form method="post" id="send_message" action="send_message.php">
					<div class="control-group">
						<p class="lead">Contactos</p>
						<div>
							<select class="form-control" name="friend_id" class="combo" required>
								<option>...</option>
								<?php
									$query = $conn->query("select members.member_id , members.firstname , members.lastname , members.image , friends.friends_id   from members  , friends
									where friends.my_friend_id = '$session_id' and members.member_id = friends.my_id
									OR friends.my_id = '$session_id' and members.member_id = friends.my_friend_id
									");
									while($row = $query->fetch()){
									$friend_name = $row['firstname']." ".$row['lastname'];
									$friend_image = $row['image'];
									$id = $row['member_id'];
								?>
								<option value="<?php echo $id; ?>"><?php echo $friend_name; ?></option>
								<?php } ?>
							</select>
						</div>
                    </div>
					<br>
					<div class="control-group">
                        <div class="controls">
							<textarea name="my_message" class="form-control" placeholder="Escribe un mensaje aquí" required></textarea>
                        </div>
                    </div>
					<br>
					<div class="control-group">
                        <div class="controls">
							<button  class="btn btn" style="color: green; border: 2px solid green; border-radius: 30px;">Enviar Mensaje</button>
                        </div>
                    </div>
                </form>
            </div>

            <div class="col-md-6 col-sm-9">
             	<p class="lead text-center">Bandeja Privada</p>	 
				<?php 
				$query = $conn->query("select * from message
				LEFT JOIN members on message.sender_id = members.member_id where reciever_id = '$session_id' ");
				while($row = $query->fetch()){
				$id = $row['message_id'];
				?>
				<br>
				<div>
				<div class="message"><?php echo $row['content']; ?>
				<br>
				<br>
				<div class="pull-left"><?php echo $row['date_sended']; ?></div>
				<div class="pull-right">Enviado por: <?php echo $row['firstname']." ".$row['lastname']; ?></div>
				<hr>
				<a href="delete_message.php<?php echo '?id='.$id; ?>" class="btn btn" style="color: red; border: 2px solid red; border-radius: 30px;">Eliminar</a>
				</div>
				</div>
				<?php } ?>
            </div>
	      </div>
        </div>
      </div>                                                  
   	</div><!--/col-12-->
  </div>
</div>
</body>
</html>