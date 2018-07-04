import React, { PropTypes } from 'react';
import {accountLogin} from './../modules/login';

class LoginForm extends React.Component {
	constructor(props) {
	    super(props);
    	this.state = {
            UserName: '',
            Password: '',
            logged: false,
			isValid: true
        };
  	}

  	handleChange = (event) => {
    	this.setState({[event.target.name]: event.target.value})
  	}

  	handleSubmit = (event) => {
    	event.preventDefault();
    	var isValid = true;
        var {UserName, Password} = this.state;

        if(isValid) {
            this.setState({ isValid: true });
            const { onReceiveData,
    			onSendingData } = this.props;
		    onSendingData();
    	    accountLogin({
                userName: UserName,
                password: Password
            }).then(result => {
                onReceiveData(result);
                if(result != null) localStorage.setItem(UserName, JSON.stringify(result.access_token));
            });
        }
  	}

  	render() {
        var { isValid } = this.state;
        
    	return (
      		<div className='loginForm'>
      			<form onSubmit={this.handleSubmit}>
          			<span>
                      Podaj login i hasło:
        			</span>
                    <table>
                        <tr>
                            <td>Login:</td>
                            <td>
                                <input type="text"
                                    name="UserName"
                                    value={this.state.UserName}
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                        <tr>
                            <td>Password:</td>
                            <td>
                                <input type="password"
                                    name="Password"
                                    value={this.state.Password}
                                    title = "Wprowadź poprawne hasło."
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                    </table>
                    <span className="bottomPadding">
                        <span className="errorWithNumber">
                            {!isValid && 'Błędne dane, proszę sprawdzić wprowadzone dane i spróbuj raz jeszcze'}
                        </span>
                    </span>
        			<span className="bottomPadding"><input type="submit" value="Log in" /></span>
    			</form>
      		</div>
    	);
  	}
}

LoginForm.propTypes = {
	onReceiveData: PropTypes.func,
  	onSendingData: PropTypes.func
}

export default LoginForm;