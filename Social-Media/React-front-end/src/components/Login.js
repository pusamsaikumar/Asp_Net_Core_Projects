import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [email,setEmail] = useState("");
  const[password,setPassword] = useState("");
  const navigate = useNavigate();
  const handleLogin= async(e)=>{
    e.preventDefault();
    // url: https://localhost:7250/api/Registration/Login
    let body ={
        Email:email,
        Password:password,

       // Name:'',
       // PhoneNo:''
    };
    var config = {
      method:'post',
      url:`https://localhost:7250/api/Registration/Login`,
      data:body
    }
await axios(config)
.then((response) => {
  // setEmail("");
  // setPassword("");
  console.log( "login res",response.data)
   const dt = response.data;
  // alert(dt.StatusMessage);
  if(dt.StatusCode === 200){
    if(email === 'admin' && password === 'admin'){
      window.localStorage.setItem("username",email);
      navigate('/admindashboard');
    } else{
      window.localStorage.setItem("loggedEmail",email);
      window.localStorage.setItem("username",dt.registration.Name);
      if(dt.registration.UserType === "staff"){
        navigate('/staffdashboard')
      } else{
        navigate('/userdashboard')
      }
    }

  }else{
    alert(dt.StatusMessage);
  }
}).catch((err) => {console.log(err)});
  }

  const handleRegister =() =>{
    window.location.href='/registration';
  }
  return (
   
  <div className="container py-5 h-100">
    <div className="row d-flex align-items-center justify-content-center h-100">
      <div className="col-md-8 col-lg-7 col-xl-6">
        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.svg"
          className="img-fluid" alt="Phone image" />
      </div>
      <div className="col-md-7 col-lg-5 col-xl-5 offset-xl-1">
        <form>
          {/* <!-- Email input --> */}
          <div className="form-outline mb-4">
            <input
             type="email" id="form1Example13" 
             className="form-control form-control-lg" 
             value={email}
             onChange={(e)=> setEmail(e.target.value)}
             />
            <label className="form-label" for="form1Example13">Email address</label>
          </div>

          {/* <!-- Password input --> */}
          <div className="form-outline mb-4">
            <input 
            type="password"
             id="form1Example23" 
             className="form-control form-control-lg"
             value={password}
             onChange={(e)=> setPassword(e.target.value)}
             />
            <label className="form-label" for="form1Example23">Password</label>
          </div>

          <div className="d-flex justify-content-around align-items-center mb-4">
            {/* <!-- Checkbox --> */}
            <div className="form-check">
              <input className="form-check-input" type="checkbox" value="" id="form1Example3" checked />
              <label className="form-check-label" for="form1Example3"> Remember me </label>
            </div>
            <a href="#!">Forgot password?</a>
          </div>

          {/* <!-- Submit button --> */}
          <button type="submit"
           className="btn btn-primary btn-lg btn-block"
            onClick={(e)=> handleLogin(e)}
           >Sign in</button>

          <div className="divider d-flex align-items-center my-4">
            <button className='btn btn-primary' onClick={handleRegister}>
                Registration
            </button>
          </div>

          <a className="btn btn-primary btn-lg btn-block" style= {{backgroundColor:" #3b5998"}} href="#!"
            role="button">
            <i className="fab fa-facebook-f me-2"></i>Continue with facebook
          </a>
          <a className="btn btn-primary btn-lg btn-block" style= {{backgroundColor:" #55acee"}}  href="#!"
            role="button">
            <i className="fab fa-twitter me-2"></i>Continue with Twitter</a>

        </form>
      </div>
    </div>
  </div>

  )
}

export default Login