<form  action="signup_save.php" method="post" autocomplete="on"> 
<h3> Registro </h3> 
<hr>
<div class="form-group"> 
    <label for="usernamesignup">Tu usuario</label>
    <input class="form-control" id="usernamesignup" name="username" required="required" type="text" placeholder="Usuario" />
</div>
<div class="form-group">
    <label for="passwordsignup">Tu contraseña </label>
    <input class="form-control" id="passwordsignup" name="password" required="required" type="password" placeholder="Contraseña"/>
</div>
<div class="form-group">
    <label for="passwordsignup">Nombre </label>
    <input class="form-control" id="passwordsignup" name="firstname" required="required" type="text" placeholder="First Name"/>
</div>								
<div class="form-group">
    <label for="passwordsignup" class="youpasswd" data-icon="u">Apellido </label>
    <input class="form-control" id="passwordsignup" name="lastname" required="required" type="text" placeholder="Last Name"/>
</div>
<label for="passwordsignup">Género </label>
<select class="form-control" id="passwordsignup"  name="gender">
    <option>Hombre</option>
    <option>Mujer</option>
</select>
<br>                            
<button class="btn btn" type="submit" name="login" style="color: red; border: 2px solid red; border-radius: 30px;"> Resgistrarse </button>                     
</form>