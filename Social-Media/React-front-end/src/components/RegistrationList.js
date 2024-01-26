import React, { useEffect, useState } from 'react';
import axios from 'axios';
import {Table} from "react-bootstrap";

const RegistrationList = () => {
    const [data,setData] = useState([]);
    console.log("data",data)
    useEffect(()=>{
      getData();
    },[]);
    const getData= async()=>{
        // url : https://localhost:7250/api/Registration/RegistrationList
        let body = {
            UserType:"user"
        };
        var config={
            method:"post",
            url:`https://localhost:7250/api/Registration/RegistrationList`,
            data:body
        }
        await axios(config).then((response) => {
                //console.log(response.data);
                const dt = response.data;
                if(dt.StatusCode === 200){
                  setData(dt.listRegistration)
                }
                
        }).catch((err) => console.log(err))

    }
  return (
    <div className='container' style={{marginTop:"20px"}} >
         <Table striped bordered hover variant="lightgrey">
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Email</th>
          <th>Phone No</th>
          {/* <th>IsActive</th> */}
          <th>IsApproved</th>
          <th>Actions</th>
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
                        <td>{each.Email}</td>
                        <td>{each.PhoneNo}</td>
                        <td>{each.IsApproved}</td>
                        <td>{each.IsApproved === 1 ? "Already Approved" : "Pending Approval"}</td>
                    </tr>
                })
              }
            </>) : (<p>No records found please try again !!!....</p>)
        }
        
       
      </tbody>
    </Table>
    </div>
  )
}

export default RegistrationList