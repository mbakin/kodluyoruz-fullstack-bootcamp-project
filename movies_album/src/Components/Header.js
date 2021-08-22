import React, {} from "react";
import PropTypes from 'prop-types';

const Header = (props) => {

  
    return (
      <div>
        <section className="pt-5 text-center container">
          <div className="row py-lg-5">
            <div className="col-lg-6 col-md-8 mx-auto">
              <h1 className="display-1">{props.title}</h1>
              <p className="lead text-muted">{props.slogan}</p>
            </div>
          </div>
        </section>
      </div>
    )
 
}

Header.defaultProps ={
  title: "Deneme baslik",
  slogan: "Deneme slogan"
}

Header.propTypes = {
  title: PropTypes.string,
  slogan: PropTypes.string
}

export default Header