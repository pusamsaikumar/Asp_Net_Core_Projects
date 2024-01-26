import React, { useEffect, useState } from 'react';
import axios from 'axios';
import {Table} from "react-bootstrap";
const ArticleList = () => {
  const [data,setData] = useState([]);
  console.log("data",data);
  useEffect(()=>{
    getData();
  },[]);
  const getData= async()=>{
      // url : https://localhost:7250/api/Article/ArticleList
      // let body = {
      //     type:"Page"
      // };
      var config={
          method:"get",
          url:`https://localhost:7250/api/Article/ArticleList`,
        
      }
      await axios(config).then((response) => {
              console.log(response.data);
              const dt = response.data;
              if(dt.StatusCode === 200){
               setData(dt.listArticle)
              }
              
      }).catch((err) => console.log(err))

  }

  const handleApproval = async(e,ID) =>{
    e.preventDefault();

       // url : https://localhost:7250/api/Article/ArticleApproval
      let body = {
          ID:ID
      };
      var config={
        method:"put",
        url:`https://localhost:7250/api/Article/ArticleApproval`,
        data:body
    }
    await axios(config).then((response) => {
            console.log(response.data);
            const dt = response.data;
            if(dt.StatusCode === 200){
            // setData(dt.listArticle)
            alert(dt.StatusMessage)
            getData();
            }
            
    }).catch((err) => console.log(err))
  }
  return (
    <div className='container' style={{marginTop:"20px"}} >
    <Table striped bordered hover variant="lightgrey">
 <thead>
   <tr>
     <th>#</th>
     <th>Title</th>
     <th>Content</th>
     <th>Email</th>
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
                   <td>{each.Title}</td>
                   <td>{each.Content}</td>
                   <td>{each.Email}</td>
                   <td>{each.IsApproved}</td>
                   <td>{each.IsApproved === 1 ? "Already Approved" 
                   : <button className='btn btn-success'onClick={(e) => handleApproval(e,each.ID)} >Mark Approve</button>}
                   </td>
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

export default ArticleList