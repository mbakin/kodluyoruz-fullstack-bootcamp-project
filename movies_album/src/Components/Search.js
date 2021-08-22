import React, { useContext, useState } from "react";
import { MovieContext } from "../context/MovieContext";

const Search = () => {


  const { searchMovie } = useContext(MovieContext)

  const [term, setTerm] = useState("")

  const handleOnSubmit = (event) =>{
    event.preventDefault()
    searchMovie(term)
  }
  const handleOnSearch =(event) => {
    //this.setState({term : event.target.value})
    setTerm(event.target.value)
  }

    return(
      <form onSubmit={handleOnSubmit} className="row g-3 mb-5">
        <div className="col-8">
          <input onChange={handleOnSearch} type="text" className="form-control" value={term} placeholder="Search.."/>
        </div>
        <div className="col-4">
          <input type="submit" value="Search" className="form-control btn-block btn btn-danger text-white" disabled={!(term)} />
        </div>
      </form>
    )
  
}

export default Search