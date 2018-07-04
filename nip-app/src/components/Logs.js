import React, { Component, PropTypes} from 'react';
import { getLogs } from './../modules/logs';

class Logs extends Component {

    handleSubmit = (event) => {
        event.preventDefault();
        const { onReceiveLogData, onAskingForData } = this.props;
        onAskingForData();
        getLogs()
            .then(result => onReceiveLogData(result));
    }

    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <span className="smallerSpan">
                        <input type="submit" value="Sprawdź logi wyszukań" />
                    </span>
                </form>
            </div>
        );
    }
}

Logs.propTypes = {
  onReceiveLogData: PropTypes.func,
  onAskingForData: PropTypes.func
}

export default Logs;