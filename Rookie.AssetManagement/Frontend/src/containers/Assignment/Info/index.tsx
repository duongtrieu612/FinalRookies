import React from "react";
import { Modal, } from "react-bootstrap";
import { User } from "react-feather";
import {
    AdminUserTypeLabel,
    StaffUserTypeLabel,
    AdminUserType,
    StaffUserType
} from "src/constants/User/UserContants";
import formatDateTime, { convertDDMMYYYY } from "src/utils/formatDateTime";
import IAssignment from "src/interfaces/Assignment/IAssignment";
type Props = {
    assignment: IAssignment;
    handleClose: () => void;
};

const Info: React.FC<Props> = ({ assignment, handleClose }) => {
    console.log(assignment)
    return (
        <>
            <Modal
                show={true}
                onHide={handleClose}
                dialogClassName="detail-modal modal-90w"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed Assignment Infomation
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div className="table-detail-large">
                        <div className='row -intro-y'>
                            <div className='col-4'>Asset Code</div>
                            <div className='col-6'>{assignment.assetCode}</div>
                        </div>

                        <div className='row -intro-y'>
                            <div className='col-4'>Asset Name</div>
                            <div className='col-6'>{assignment.assetName}</div>
                        </div>
                        <div className='row -intro-y'>
                            <div className='col-4'>Specification</div>
                            <div className='col-6'>{assignment.specification}</div>
                        </div>
                        <div className='row -intro-y'>
                            <div className='col-4'>Assigned to</div>
                            <div className='col-6'>{assignment.assignedTo}</div>
                        </div>
                        <div className='row -intro-y'>
                            <div className='col-4'>Assigned by</div>
                            <div className='col-6'>{assignment.assignedBy}</div>
                        </div> 
                        <div className='row -intro-y'>
                            <div className='col-4'>Assigned Date</div>
                            <div className='col-6'>{convertDDMMYYYY(assignment.assignedDate)}</div>
                        </div>
                        <div className='row -intro-y'>
                            <div className='col-4'>State</div>
                            <div className='col-6'>{assignment.state}</div>
                        </div>
                        <div className='row -intro-y'>
                            <div className='col-4'>Note</div>
                            <div className='col-6'>{assignment.note}</div>
                        </div>

                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
}

export default Info;