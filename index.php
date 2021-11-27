<?php include('header.php'); ?>
<?php include('dbcon.php'); ?>
    <body>
        <div class="container">
            <h1 class="text-center">Bienvenidos a Worki</h1>			
            <hr>
            <div class="row">
                <div class="col-md-6">
                <?php include('login_form.php'); ?>
                </div>
                <div class="col-md-6">
                <?php include('sign_up_form.php'); ?>
                </div> 
            </div>          
        </div>
    </body>
</html>