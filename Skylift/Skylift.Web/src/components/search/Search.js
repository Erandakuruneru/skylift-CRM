import React, { Component } from "react";

class Search extends Component {
  constructor(props, context) {
    super(props, context);
    this.state = {
      isClickSearch: false,
    };
    this.onClickSearch = this.onClickSearch.bind(this);
  }

  onClickSearch(event) {
    this.setState({
      isClickSearch: !this.state.isClickSearch,
    });
  }

  render() {
    return (
      <div>
        <header className="header">
          <div className="header__menu">
            <a className="header__brand" href="index.html"></a>

            <button
              className="hamburger hamburger--collapse js-hamburger"
              type="button"
              aria-label="Menu"
              aria-controls="navigation"
            >
              <span className="hamburger-label">Menu</span>
              <span className="hamburger-box">
                <span className="hamburger-inner"></span>
              </span>
            </button>

            <a className="header__search js-search" href="index.html"></a>
          </div>
          <div className="container">
            <div className="popover-menu">
              <ul className="popover-menu__list">
                <li className="popover-menu__item">
                  <a
                    href="#"
                    className="popover-menu__link popover-menu__link--has-child   menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children "
                  >
                    Capabilities <span className="popover-menu__link-more">+</span>{" "}
                    <span className="popover-menu__angle"></span>{" "}
                  </a>
                  <div className="popover-menu__child">
                    <div className="container">
                      <div className="row popover-menu__child-row">
                        <div className="col">
                          <div className="row">
                            <div className="col">
                              <a
                                href="#"
                                className="popover-menu__back js-menu-back-button"
                              >
                                Capabilities
                              </a>
                              <ul className="popover-menu__child-list">
                                <li className="popover-menu__child-item  is-active ">
                                  <a
                                    href="capabilities/transport-and-freight/index.html"
                                    className="popover-menu__child-link popover-menu__link--2"
                                  >
                                    <span>Transport and freight</span>
                                  </a>
                                  <ul className="popover-menu__child-list popover-menu__child-list-child">
                                    <li className="popover-menu__child-item">
                                      <a
                                        href="capabilities/transport-and-freight/index.html#road-freight"
                                        className="popover-menu__child-link popover-menu__link--3"
                                      >
                                        Road freight
                                      </a>
                                    </li>
                                  </ul>
                                </li>
                              </ul>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </li>
              </ul>
              <div className="popover-menu__image">
                <img src="./assets/images/feature-image.jpg" />
                <div className="popover-menu__follow">
                  <strong className="popover-menu__follow-heading">Follow</strong>
                </div>
              </div>
            </div>
          </div>
        </header>
      </div>
    );
  }
}

export default Search;
