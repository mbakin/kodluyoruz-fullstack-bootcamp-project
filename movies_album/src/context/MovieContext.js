import React, { createContext, useEffect, useState } from 'react';


export const MovieContext = createContext()

export const MovieProvider = (props) => {
  
    const [movies, setMovies] = useState([])
  const [loading, setLoading] = useState(false)

   useEffect(()=>{
     getMovies()
   }, [])

  const getMovies = () => {
    //this.setState({loading: true})
    setLoading(true)
    fetch('https://api.themoviedb.org/3/movie/popular?api_key=49ab29ee9150d894f60ff78eed46e7fc')
      .then(response => response.json())
      .then(data => {
        //this.setState({movies : data.results, loading: false}))
        setMovies(data.results)
        setLoading(false)
      }
      )
    }
  

  const searchMovie = (term) => {
    fetch(`https://api.themoviedb.org/3/search/movie?api_key=49ab29ee9150d894f60ff78eed46e7fc&query=${term}`)
      .then(response => response.json())
      .then(data => setMovies( data.results))
  }

  return(
    <MovieContext.Provider value={{
      movies,
      searchMovie,
      loading,
      getMovies
    }}>
      {props.children}
    </MovieContext.Provider>
  )
}