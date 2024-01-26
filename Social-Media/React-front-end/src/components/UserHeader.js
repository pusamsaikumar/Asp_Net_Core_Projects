import React, { useEffect, useState } from 'react';
import {useNavigate,Link} from "react-router-dom";


const UserHeader = () => {
    const [userName,setUserName] = useState("");
const navigate = useNavigate();

    useEffect(()=>{
       setUserName( window.localStorage.getItem("username"));
    },[]);
    const logout =(e)=>{
        e.preventDefault();
        window.localStorage.removeItem("username");
        navigate('/');
    }
  return (
 
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
      <a className="navbar-brand" href="#">SocialNetWork</a>
  <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
    <span className="navbar-toggler-icon"></span>
  </button>

  <div className="collapse navbar-collapse" id="navbarTogglerDemo02">
    <ul className="navbar-nav mr-auto ">
      <li className="nav-item active">
        <a className="nav-link" href="#"> Welcome <span>{userName}</span> </a>
      </li>
      <li className="nav-item">
        <Link to="/userarticle" className='nav-link' >Add Article</Link>
        
      </li>
      <li className="nav-item">
      <Link to="/usernews"  className='nav-link'>News</Link>
        
      </li>
     
    </ul>


    <form className="form-inline my-2 my-lg-0" style={{marginLeft:"1000px"}}>
  <button className="btn btn-outline-success my-2 my-sm-0" type="submit" 
    onClick={(e)=>logout(e)}
  >Logout</button>
  </form>
  </div>
</nav>
    
  )
}

export default UserHeader