import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table } from "react-bootstrap";

const UserArticleList = () => {
  const [data, setData] = useState([]); 
  const [title,setTitle] = useState("");
  const [content,setContent] = useState("");
  const [file,setFile] = useState("");
  const [fileName,setFileName] = useState("");
  
  useEffect(() => {
    getData();
  }, []);

  const getData = async () => {
    // url : https://localhost:7250/api/News/getNewsList
    let body = {
       Email:localStorage.getItem("loggedEmail")
       // Email:'sai@gmail.com',
      
    };
    var config = {
      method: "post",
      url: `https://localhost:7250/api/Article/ArticleListUser`,
    data:body
    }
    await axios(config).then((response) => {
      console.log(response.data);
      const dt = response.data;
      if (dt.StatusCode === 200) {
        setData(dt.listArticle)
      }

    }).catch((err) => console.log(err))

  }
  const Clear=(e)=>{
    e.preventDefault();
    setTitle("");
    setContent("");
    setFile("");
    setFileName("");
    
  }

  const handleSave= async(e)=>{
    // url:https://localhost:7250/api/News/createNews
    e.preventDefault();
    const data={
      Title:title,
      Content:content,
      Email:localStorage.getItem("loggedEmail"),
      Image:fileName,
      type:"User"
    }

    const formData = new FormData();
formData.append("FileName",fileName);
formData.append("file",file);   

// https://localhost:7250/Photos/banners3.webp url: for the photos to get from db
//  https://localhost:7250/api/FileUpload/SaveFile  // to insert into the db

// try{
//     const res=  await axios.post('https://localhost:7250/api/FileUpload/SaveFile',formData);
//     //console.log("res",res);
//     if(res.data === fileName){
//         const res = await axios.post('https://localhost:7250/api/Article/AddArticle',data);
//         if(res.data.StatusCode === 200){
//             Clear(e);
//             getData();
//             alert("Added article")
//         }else{
//             alert(res.data.StatusMessage)
//         }
//     }
// }catch(err){

// }

try{
     const res = await axios.post(" https://localhost:7250/api/FileUpload/uploadFile",formData);
     console.log("res",res);
     if(res.data.StatusCode === 200 ){
        const res = await axios.post('https://localhost:7250/api/Article/AddArticle',data);
        if(res.data.StatusCode === 200) {
            getData();
            Clear(e);
            alert("Article details are added"); 
        } else{
            alert(res.data.StatusMessage);
        }
       
     }

}catch(err){

}   
  }

  const saveFile =(e)=>{
    setFile(e.target.files[0]);
    setFileName(e.target.files[0]?.name)
  }


  return (
    <div className='container'>
      <h4 style={{textAlign :"center",marginTop:"10px"}}>Add Article</h4>
      <form>
        <div class="form-group mt-20px col-md-12" >
          {/* <label for="exampleFormControlInput1">Title</label> */}
          <input type="text" class="form-control" id="exampleFormControlInput1" placeholder="Enter Title" value={title} 
            onChange={(e) => setTitle(e.target.value)}
          />
        </div>
        <div class="form-group mt-20px col-md-12" style={{marginTop:'20px'}} >
          {/* <label for="exampleFormControlInput1">SaveFile</label> */}
          <input type="file" class="form-control" id="exampleFormControlInput1" 
          onChange={(e) => saveFile(e)}
          />
        </div>
       <div className='form-group mt-20px col-md-12' style={{marginTop:"20px"}}>
       {/* <label for="exampleFormControlTextarea1">Example textarea</label> */}
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
     <th>Image</th>

     <th>IsApproved</th>
     <th>Status</th>
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
                   {/* <td>{each.Image}</td> */}
                   <td>
                    <img className='form-control' src={`https://localhost:7250/Photos/${each.Image}`} alt=""  width={"50px"} height={"50px"} style={{objectFit:"contain"}} />
                   </td>


                     <td>{each.IsApproved}</td>
                   <td>{each.IsApproved === 1 ? "Already Approved" : "Pending Approval"  }
              
                   </td> 
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

export default UserArticleList