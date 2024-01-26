import React, { useEffect, useState } from 'react';
import {useNavigate,Link} from "react-router-dom"; 
const AdminHeader = () => {
  const [userName,setUserName] = useState("");
  const navigate = useNavigate();
  useEffect(()=>{
   setUserName( localStorage.getItem("username"))
  },[])
  const logout =(e)=>{
    e.preventDefault();
   window.localStorage.removeItem("username")
    navigate('/');
}
  return (
<React.Fragment>
<nav className="navbar navbar-expand-lg navbar-light bg-light">
    <a className="navbar-brand" href="#">SocialNetWork</a>
<button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
  <span className="navbar-toggler-icon"></span>
</button>

<div className="collapse navbar-collapse" id="navbarTogglerDemo02">
  <ul className="navbar-nav mr-auto mt-2 mt-lg-0">
    <li className="nav-item active">
      <a className="nav-link" href="#"> Welcome <span className='sr-only'>Admin</span> </a>
    </li>
    <li className="nav-item">
     
        <Link to={"/registrationlist"} className='nav-link'>
        Registration Mangement
        </Link> 
       
          
    
    </li>
    <li className="nav-item">
      <Link to={"/articlelist"} className='nav-link'>
        Article Mangement
      </Link>
     
    </li>
    <li className="nav-item">
      <Link to={"/newslist"} className='nav-link'>
        News Mangement
      </Link>
     
    </li>
    <li className="nav-item">
      <Link to={"/stafflist"} className='nav-link'>
        Staff Mangement
      </Link>
     
    </li>
   
  </ul>

  <form className="form-inline my-2 my-lg-0" style={{marginLeft:'450px'}} >
  <button className="btn btn-outline-success my-2 my-sm-0" type="submit" 
    onClick={(e)=>logout(e)}
  >Logout</button>
  </form>
  

</div>
</nav>
</React.Fragment>
  )
}

export default AdminHeader