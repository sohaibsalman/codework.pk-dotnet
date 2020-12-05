import React from "react";
import {
  BrowserRouter as Router,
  Redirect,
  Route,
  Switch,
} from "react-router-dom";
import Login from "./components/pages/login/login";
import Signup from "./components/pages/signup/signup";

function App() {
  return (
    <React.Fragment>
      <Router>
        <Switch>
          <Route path="/login" component={Login} />
          <Route path="/signup" component={Signup} />
          <Redirect from="/" to="/login" exact />
        </Switch>
      </Router>
    </React.Fragment>
  );
}

export default App;
