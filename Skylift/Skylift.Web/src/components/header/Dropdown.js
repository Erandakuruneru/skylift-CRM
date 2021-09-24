import React  from 'react';

const Dropdown = () => {
  return (
    <ul className="dropdown-menu" aria-labelledby="dropdown01">
    <li><a className="dropdown-item" href="article.html">Article Details</a></li>
    <li><div className="dropdown-divider"></div></li>
    <li><a className="dropdown-item" href="terms.html">Terms Conditions</a></li>
    <li><div className="dropdown-divider"></div></li>
    <li><a className="dropdown-item" href="privacy.html">Privacy Policy</a></li> 
    <div className="dropdown-item">
    </div>
    </ul>       
  );
};

export default Dropdown;
