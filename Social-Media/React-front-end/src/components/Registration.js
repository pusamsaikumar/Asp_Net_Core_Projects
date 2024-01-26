import React, { useState } from 'react';
import axios from 'axios';

const Registration = () => {
  const [name,setName] = useState("");
  const[email,setEmail]= useState("");
  const[password,setPassword] = useState("");
  const[phoneNo,setPhoneNo] = useState("");


  // url: https://localhost:7250/api/Registration/Registration
  const handleSave= async(e)=>{
    e.preventDefault();
    console.log(name,email,password,phoneNo);

    let body = {
      Name : name,
      Email:email,
      Password :password,
      PhoneNo :phoneNo,
    };
    var config={
      method:"post",
      url:`https://localhost:7250/api/Registration/Registration`,
      data:body
    }
  await axios(config).then((response) => {
    //console.log(response.data);
    setName("");
    setEmail("");
    setPassword("");
    setPhoneNo("");
    const dt = response.data;
    alert(dt.StatusMessage);
  })
  .catch((error) => {
    console.log(error)
  })

  // await axios.post("",data).then((res) => console(res.data)).catch((err)=>console.log(err))
  };

  const resetData=()=>{
    setName("");
    setEmail("");
    setPassword("");
    setPhoneNo("")
  }
  const handleLogin=()=>{
    window.location.href='/';
  }
  return (
    <section className="h-100 bg-dark">
    <div className="container py-5 h-100">
      <div className="row d-flex justify-content-center align-items-center h-100">
        <div className="col">
          <div className="card card-registration my-4">
            <div className="row g-0">
              <div className="col-xl-6 d-none d-xl-block">
                <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/img4.webp"
                  alt="Sample photo" className="img-fluid"
                  //style="border-top-left-radius: .25rem; border-bottom-left-radius: .25rem;" 
                  style={{borderTopLeftRadius:".25rem",borderBottomLeftRadius:".25rem"}}
                  />
              </div>
              <div className="col-xl-6">
                <div className="card-body p-md-5 text-black">
                  <h3 className="mb-5 text-uppercase">Student registration form</h3>
         
                  <div className="form-outline mb-4">
                    <input 
                    type="text" 
                    id="form3Example97" 
                    className="form-control form-control-lg"
                    value={name}
                    onChange={(e)=>setName(e.target.value)}
                     />
                    <label className="form-label" for="form3Example97">Name</label>
                  </div>
  
                  <div className="form-outline mb-4">
                    <input type="text" 
                    id="form3Example97" 
                    className="form-control form-control-lg"
                    value={email}
                    onChange={(e)=>setEmail(e.target.value)}
                    
                    />
                    <label className="form-label" for="form3Example97">Email ID</label>
                  </div>
  
                  <div className="form-outline mb-4">
                    <input type="text" 
                    id="form3Example8"
                     className="form-control form-control-lg"
                     value={password}
                     onChange={(e)=>setPassword(e.target.value)}
                     />
                    <label className="form-label" for="form3Example8">Password</label>
                  </div>
                  <div className="form-outline mb-4">
                    <input type="number"
                     id="form3Example9" 
                     className="form-control form-control-lg"
                     value={phoneNo}
                     onChange={(e)=>setPhoneNo(e.target.value)}
                     />
                    <label className="form-label" for="form3Example97">Phone No</label>
                  </div>
                  <div className="d-flex justify-content-end pt-3">
                    <button 
                    type="button" 
                    className="btn btn-light btn-lg"
                    onClick={()=>resetData()}
                    >
                      Reset all</button>
                    <button type="button" 
                    className="btn btn-warning btn-lg ms-2"
                    onClick={(e)=>handleSave(e)}
                    >Submit form</button>
                    <button type="button" 
                    className="btn btn-secondary btn-lg ms-2"
                    onClick={()=>handleLogin()}
                    >Login</button>
                  </div>
  
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
  )
}

export default Registration