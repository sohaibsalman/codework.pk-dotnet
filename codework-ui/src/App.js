import React from "react";
import Login from "./components/pages/login/login";
import {
  BrowserRouter as Router,
  Redirect,
  Route,
  Switch,
} from "react-router-dom";

function App() {
  return (
    <React.Fragment>
      <Router>
        <Switch>
          <Route path="/login" component={Login} />
          <Redirect from="/" to="/login" />
        </Switch>
      </Router>
    </React.Fragment>
  );
}

export default App;
