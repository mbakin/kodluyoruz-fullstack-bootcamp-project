import React, {useContext} from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Navbar from './Components/Navbar';
import Header from './Components/Header';
import Search from "./Components/Search";
import CardList from "./Components/CardList";
import Footer from "./Components/Footer";
import About from "./Components/About";
import CardDetail from "./Components/CardDetail";
import { MovieContext } from "./context/MovieContext";


const App = () =>  {

  
  const { loading } = useContext(MovieContext)
  
    return (
      <Router>
        
          <>
        <Navbar/>
        <Switch>
          <Route exact path="/">
            <main>
              <Header title="Movies Album" slogan="Sample slogan text"/>
              <div className="album py-5 bg-light">
                <div className="container">
                  <Search />
                  {
                    loading ?
                      (
                        <div className="spinner-border text-danger" role="status">
                          <span className="visually-hidden">Loading...</span>
                        </div>
                      )
                      :
                      <CardList />
                  }
                </div>
              </div>
            </main>
          </Route>
        
        <Route path="/about" component={About} />
        <Route path="/movies/:id" component={CardDetail} />
        
        </Switch>
        <Footer/>
        </>
        
      </Router>
      
    );
  }

export default App;
