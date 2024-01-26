import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table } from "react-bootstrap";
const StaffList = () => {

  // url: https://localhost:7250/api/Registration/StaffRegistration
  const [data, setData] = useState([]); 
  const [name,setName] = useState("");
  const [email,setEmail] = useState("");
  const [password,setPassword] = useState("");
  console.log("data", data);
  useEffect(() => {
    getData();
  }, []);
  const getData= async()=>{
    // url : https://localhost:7250/api/Registration/RegistrationList
    let body = {
        UserType:"staff"
    };
    var config={
        method:"post",
       // url:`https://localhost:7250/api/Registration/RegistrationList`,
       url:`https://localhost:7250/api/Registration/StaffRegistrationList`,
        data:body
    }
    await axios(config).then((response) => {
            //console.log(response.data);
            const dt = response.data;
            if(dt.StatusCode === 200){
              setData(dt.staffs)
            }
            
    }).catch((err) => console.log(err))

}
  const Clear=(e)=>{
    e.preventDefault();
    setName("");
    setEmail("");
    setPassword("");
  
  }
  const handleSave= async(e)=>{
    // url:https://localhost:7250/api/News/createNews
    e.preventDefault();
    let body={
      Name:name,
    
      Email:email,
      Password:password,
    //  UserType:'staff'
    }
    var config ={
      method:'post',
      url:`https://localhost:7250/api/Registration/StaffRegistration`,
      data:body
    }
    await axios(config).then((response) =>{
      const dt=response.data;
      if(dt.StatusCode === 200){
          getData();
          Clear(e);
          alert("Staff added")
      } else{
        alert(dt.StatusMessage)
      }
    })
  }
  return (
    <div className='container'>
    <h4 style={{textAlign :"center",marginTop:"10px"}}>Add News</h4>
    <form>
      <div class="form-group mt-20px row" >
        {/* <label for="exampleFormControlInput1">Title</label> */}
      <div className='col-md-6'>
      <input type="text" class="form-control" id="exampleFormControlInput1" placeholder="Enter Title" value={name} 
          onChange={(e) => setName(e.target.value)}
        />
      </div>
      <div className='col-md-6'>
      <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="Enter Email" value={email} 
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>
       
       
      </div>
     <div className='form-group mt-20px col-md-12' style={{marginTop:"20px"}}>
     {/* <label for="exampleFormControlTextarea1">Example textarea</label> */}
     <input type="password" class="form-control" id="exampleFormControlInput1" placeholder="Enter Password" value={password} 
          onChange={(e) => setPassword(e.target.value)}
        />
     </div>
     <div className='form-group col-md-6' style={{marginTop:"20px"}}>
        <button className='btn btn-primary' style={{width:"150px",float:"left",marginRight:"100px"}}
         onClick={(e) => handleSave(e)}
        >
          Save 
        </button> {"  "}
        <button className='btn btn-danger' style={{width:'150px'}} onClick={(e) => Clear(e)}>
          Reset
        </button>
     </div>
    </form>
    <div style={{marginTop:"20px"}}>
    <Table striped bordered hover variant="lightgrey">
<thead>
 <tr>
   <th>#</th>
   <th>Name</th>
  
   <th>Email</th>
   
  
 </tr>
</thead>
<tbody>
 {
   data.length > 0 ? (<>
       {
         data?.map((each) =>{
             return <tr key={each.ID}>
                 <td>{each.ID}</td>
                 <td>{each.Name}</td>
                 {/* <td>{each.Content}</td> */}
                 <td>{each.Email}</td>
                 {/* <td>{each.CreatedOn.slice(0,10)}</td> */}
                 {/* <td>{each.IsApproved}</td>
                 <td>{each.IsApproved === 1 ? "Already Approved" 
                 : <button className='btn btn-success'onClick={(e) => handleApproval(e,each.ID)} >Mark Approve</button>}
                 </td> */}
             </tr>
         })
       }
     </>) : (<p>No records found please try again !!!....</p>)
 }
 

</tbody>
</Table>
    </div>
  </div>
  )
}

export default StaffList