import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table } from "react-bootstrap";

const UserNews = () => {
  const [data, setData] = useState([]); 
  const [title,setTitle] = useState("");
  const [content,setContent] = useState("");
  console.log("data", data);
  useEffect(() => {
    getData();
  }, []);
  const getData = async () => {
    // url : https://localhost:7250/api/News/getNewsList
    // let body = {
    //     type:"Page"
    // };
    var config = {
      method: "get",
      url: `https://localhost:7250/api/News/getNewsList`,

    }
    await axios(config).then((response) => {
      console.log(response.data);
      const dt = response.data;
      if (dt.StatusCode === 200) {
        setData(dt.listNews)
      }

    }).catch((err) => console.log(err))

  }
  const Clear=(e)=>{
    e.preventDefault();
    setTitle("");
    setContent("");
  }
  const handleSave= async(e)=>{
    // url:https://localhost:7250/api/News/createNews
    e.preventDefault();
    let body={
      Title:title,
      Content:content,
      Email:localStorage.getItem("loggedEmail")
    }
    var config ={
      method:'post',
      url:`https://localhost:7250/api/News/createNews`,
      data:body
    }
    await axios(config).then((response) =>{
      const dt=response.data;
      if(dt.StatusCode === 200){
          getData();
          Clear(e);
          alert("Added News")
      } else{
        alert(dt.StatusMessage)
      }
    })
  }
  return (
    <div className='container'>
      <h4 style={{textAlign :"center",marginTop:"10px"}}>Add News</h4>
      <form>
        <div class="form-group mt-20px col-md-12" >
          <label for="exampleFormControlInput1">Title</label>
          <input type="text" class="form-control" id="exampleFormControlInput1" placeholder="Enter Title" value={title} 
            onChange={(e) => setTitle(e.target.value)}
          />
        </div>
       <div className='form-group mt-20px col-md-12' style={{marginTop:"20px"}}>
       <label for="exampleFormControlTextarea1">Example textarea</label>
        <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" placeholder='Enter Content'
        value={content}
        onChange={(e) => setContent(e.target.value)}
        ></textarea>
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
     <th>Title</th>
     <th>Content</th>
     <th>Email</th>
     <th>Created On</th>
     {/* <th>IsActive</th> */}
     {/* <th>IsApproved</th>
     <th>Actions</th> */}
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
                   <td>{each.CreatedOn.slice(0,10)}</td>
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

export default UserNews;