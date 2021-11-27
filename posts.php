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
    <h1>¿Que estas pensando?</h1>
  </div>
</div>
<br>
<div class="container">
  <div class="col-md-12">
	<form method="post" action="post.php">
		<textarea name="content" class="form-control" rows="3" placeholder="Haz tus comentarios aquí" height="350" width="350"></textarea>
		<br>
        <br>
        <button class="btn btn" style="color: black; border: 2px solid #000000; border-radius: 30px;"> Compartir </button>
	</form>
  </div>
</div>

<div class="container">
  <div class="row">
    <div class="col-md-10 col-md-offset-1"> 
      <div class="panel">
        <div class="panel-body">
          <!--/stories-->
          <div class="row">    
            <br>
            <?php
            $query = $conn->query("select * from post LEFT JOIN members on members.member_id = post.member_id order by post_id DESC");
            while($row = $query->fetch()){
            $posted_by = $row['firstname']." ".$row['lastname'];
            $posted_image = $row['image'];
            $id = $row['post_id'];
            ?>
            <div class="col-md-2 col-sm-3 text-center">
             <img  src="<?php echo $posted_image; ?>" style="width:100px;height:100px" class="img-circle"></a>
            </div>
            <div class="col-md-10 col-sm-9">
               <div class="alert"><?php echo $row['content']; ?></div>
                    <div class="row">
                        <div class="col-xs-9">
                        <h4><span class="label label-success"> <?php echo $row['date_posted']; ?></span></h4><h4>
                        <small style="font-family:courier,'new courier';" class="text-muted">Posteado por:<a href="#" class="text-muted"><?php echo $posted_by; ?></a></small>
                        </h4>
                    </div>
                    <br>
                <div class="col-xs-3"><a href="delete_post.php<?php echo '?id='.$id; ?>" class="btn btn" style="color: red; border: 2px solid red; border-radius: 30px;">Borrar</a></div>
            </div>
            <br><br>
           </div>
           <?php } ?>    
        </div>
        <hr>
      </div>
    </div>
</div>