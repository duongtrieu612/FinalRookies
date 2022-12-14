import React, { useState } from "react";
import { ArrowCounterclockwise, CheckLg, XLg } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from 'react-notifications';

import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import formatDateTime, { convertDDMMYYYY } from "src/utils/formatDateTime";
//import Info from "../Info";

// import { EDIT_ASSIGNMENT_ID } from "src/constants/pages";
import ConfirmModal from "src/components/ConfirmModal";
import { useAppDispatch } from "src/hooks/redux";
import IReturning from "src/interfaces/Returning/IReturning";


const columns: IColumnOption[] = [
    { columnName: "No.", columnValue: "id" },
    { columnName: "Asset Code ", columnValue: "assetCode" },
    { columnName: "Asset Name ", columnValue: "assetName" },
    { columnName: "Requested by ", columnValue: "requestedBy" },
    { columnName: "Assigned Date ", columnValue: "assignedDate" },
    { columnName: "Accepted by ", columnValue: "acceptedBy" },
    { columnName: "Returned Date ", columnValue: "returnedDate" },
    { columnName: "State ", columnValue: "state" },
];


type Props = {
    returnings: IPagedModel<IReturning> | null;
    result: IReturning | null;
    handlePage: (page: number) => void;
    handleSort: (colValue: string) => void;
    handleCancel: Function;
    sortState: SortType;
    fetchData: Function;
};

const ReturningTable: React.FC<Props> = ({
    returnings,
    result,
    handlePage,
    handleSort,
    sortState,
    fetchData,
    handleCancel,
}) => {
    const dispatch = useAppDispatch();
    //const [showDetail, setShowDetail] = useState(false);
    //const [assignmentDetail, setAssignmentDetail] = useState(null as IReturning | null);
    const [cancelState, setCancel] = useState({
        isOpen: false,
        id: 0,
        title: '',
        message: '',
        isDisable: true,
        callback: () => { }
    });

    const handleShowCancel = async (id: number) => {
        setCancel({
            id,
            isOpen: true,
            title: 'Are you sure?',
            message: 'Do you want to cancel this returning request?',
            isDisable: true,
            callback: () => { }
        });
    };

    const handleShowComplete = async (id: number) => {
        setCancel({
            id,
            isOpen: true,
            title: 'Are you sure?',
            message: "Do you want to mark this returning request as 'Completed'?",
            isDisable: true,
            callback: () => { }
        });
    };

    const handleCloseCancel = () => {
        setCancel({
            isOpen: false,
            id: 0,
            title: '',
            message: '',
            isDisable: true,
            callback: () => { }
        });
    };

    const onCancel = () => {
        handleCancel(cancelState.id)
        setCancel({
            isOpen: false,
            id: 0,
            title: '',
            message: '',
            isDisable: true,
            callback: () => { }
        });
    };

    let rows
    if (result && returnings) {
        rows = [...returnings.items]
        const index = rows.findIndex(r => r.id === result.id)
        if (index >= 0) {
            rows.splice(index, 1)
        }
        rows.unshift(result)
    } else if (returnings) {
        rows = [...returnings.items]
    }
    return (
        <>
            <Table
                columns={columns}
                handleSort={handleSort}
                sortState={sortState}
                page={{
                    currentPage: returnings?.currentPage,
                    totalPage: returnings?.totalPages,
                    handleChange: handlePage,
                }}
            >
                {rows?.map((data, index) => (
                    <tr key={index} className="">
                        <td>{result ? index + 1 : data.no}</td>
                        <td>{data.assetCode}</td>
                        <td>{data.assetName}</td>
                        <td>{data.requestedBy}</td>
                        <td>{convertDDMMYYYY(data.assignedDate)}</td>
                        <td>{data.acceptedBy}</td>
                        <td>{convertDDMMYYYY(data.returnedDate)}</td>
                        <td>{data.state}</td>
                        <td className="d-flex">
                            {(() => {
                                if (data.state == "Completed") {
                                    return (
                                        <>
                                            <ButtonIcon disable={true} >
                                                <CheckLg className="text-danger" />
                                            </ButtonIcon>
                                            <ButtonIcon disable={true} onClick={() => handleShowCancel(data.id)}>
                                                <XLg className="text-black mx-2" />
                                            </ButtonIcon>
                                        </>
                                    )
                                } else {
                                    return (
                                        <>
                                            <ButtonIcon >
                                                <CheckLg className="text-danger" onClick={() => handleShowComplete(data.id)}/>
                                            </ButtonIcon>
                                            <ButtonIcon onClick={() => handleShowCancel(data.id)}>
                                                <XLg className="text-black mx-2" />
                                            </ButtonIcon>
                                        </>
                                    )
                                }
                            })()}
                        </td>
                    </tr>
                ))}
            </Table>
            <ConfirmModal
                title={cancelState.title}
                isShow={cancelState.isOpen}
                onHide={handleCloseCancel}
            >
                <div>

                    <div className="text-start">
                        {cancelState.message}
                    </div>
                    {
                        cancelState.isDisable && (
                            <div className="text-start mt-3">
                                <button
                                    className="btn btn-danger mr-3"
                                    type="button"
                                    onClick={onCancel}
                                >
                                    Yes
                                </button>

                                <button
                                    className="btn btn-outline-secondary"
                                    onClick={handleCloseCancel}
                                    type="button"
                                >
                                    No
                                </button>
                            </div>
                        )
                    }
                </div>
            </ConfirmModal>
        </>
    );
};

export default ReturningTable;