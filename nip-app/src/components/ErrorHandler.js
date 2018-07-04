import React, {Component} from 'react';

class ErrorHandler extends Component {
    render() {
        const { errorMessage } = this.props;
        
        return(
            <div>
                {errorMessage}
            </div>
        )
    }
}

export default ErrorHandler;