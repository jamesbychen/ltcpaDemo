<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="WebApplication1.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>住民資料維護</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSubmit').click(function () {
                var flag = true;
                if ($('#txbFirstname').val() == '') {
                    flag = false;
                    alert('Must have first name!');
                    $('#txbFirstname').focus();
                } else if ($('#txbLastname').val() == '') {
                    flag = false;
                    alert('Must have last name!');
                    $('#txbLastname').focus();
                } else if ($('#txbSocialid').val() == '') {
                    flag = false;
                    alert('Must have social ID!');
                    $('#txbSocialid').focus();
                }
                return flag;
            });
        });
    </script>
    <style type="text/css">
        #wrapper {
            width: 450px;
            margin: 0 auto;
            font-family: Verdana, sans-serif;
        }

        legend {
            color: #0481b1;
            font-size: 16px;
            padding: 0 10px;
            background: #fff;
            -moz-border-radius: 4px;
            box-shadow: 0 1px 5px rgba(4, 129, 177, 0.5);
            padding: 5px 10px;
            text-transform: uppercase;
            font-family: Helvetica, sans-serif;
            font-weight: bold;
        }

        fieldset {
            border-radius: 4px;
            background: #fff;
            background: -moz-linear-gradient(#fff, #f9fdff);
            background: -o-linear-gradient(#fff, #f9fdff);
            background: -webkit-gradient(linear, 0% 0%, 0% 100%, from(#fff), to(#f9fdff));
            / background: -webkit-linear-gradient(#fff, #f9fdff);
            padding: 20px;
            border-color: rgba(4, 129, 177, 0.4);
        }

        input,
        textarea {
            color: #373737;
            background: #fff;
            border: 1px solid #CCCCCC;
            color: #aaa;
            font-size: 14px;
            line-height: 1.2em;
            margin-bottom: 15px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
            box-shadow: 0 1px 2px rgba(0, 0, 0, 0.1) inset, 0 1px 0 rgba(255, 255, 255, 0.2);
        }

            input[type="text"],
            input[type="password"] {
                padding: 8px 6px;
                height: 22px;
                width: 280px;
            }

                input[type="text"]:focus,
                input[type="password"]:focus {
                    background: #f5fcfe;
                    text-indent: 0;
                    z-index: 1;
                    color: #373737;
                    -webkit-transition-duration: 400ms;
                    -webkit-transition-property: width, background;
                    -webkit-transition-timing-function: ease;
                    -moz-transition-duration: 400ms;
                    -moz-transition-property: width, background;
                    -moz-transition-timing-function: ease;
                    -o-transition-duration: 400ms;
                    -o-transition-property: width, background;
                    -o-transition-timing-function: ease;
                    width: 380px;
                    border-color: #ccc;
                    box-shadow: 0 0 5px rgba(4, 129, 177, 0.5);
                    opacity: 0.6;
                }

            input[type="submit"] {
                background: #222;
                border: none;
                text-shadow: 0 -1px 0 rgba(0,0,0,0.3);
                text-transform: uppercase;
                color: #eee;
                cursor: pointer;
                font-size: 15px;
                margin: 5px 0;
                padding: 5px 22px;
                -moz-border-radius: 4px;
                border-radius: 4px;
                -webkit-border-radius: 4px;
                -webkit-box-shadow: 0px 1px 2px rgba(0,0,0,0.3);
                -moz-box-shadow: 0px 1px 2px rgba(0,0,0,0.3);
                box-shadow: 0px 1px 2px rgba(0,0,0,0.3);
            }

        textarea {
            padding: 3px;
            width: 96%;
            height: 100px;
        }

            textarea:focus {
                background: #ebf8fd;
                text-indent: 0;
                z-index: 1;
                color: #373737;
                opacity: 0.6;
                box-shadow: 0 0 5px rgba(4, 129, 177, 0.5);
                border-color: #ccc;
            }

        .small {
            line-height: 14px;
            font-size: 12px;
            color: #999898;
            margin-bottom: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="pnList">
            <div>
                <asp:Button runat="server" ID="btnAdd" Text="新增" OnClick="btnAdd_Click" />
            </div>
            <asp:DataGrid runat="server" ID="dgList" CellPadding="3" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="dgList_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" Text="選取"></asp:ButtonColumn>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <ItemStyle ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:DataGrid>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LTCPAConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT sn, name, gender, telephone1, socialID, birthday FROM View_Resident"></asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnEdit">
            <asp:TextBox runat="server" ID="txbSn" Visible="false"></asp:TextBox>
            <div id="wrapper">
                <fieldset>
                    <div>
                        <asp:TextBox placeholder="First Name" runat="server" ID="txbFirstname" MaxLength="20"></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox placeholder="Last Name" runat="server" ID="txbLastname" MaxLength="20"></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txbSocialid" MaxLength="10" placeholder="Social ID"></asp:TextBox>
                    </div>
                    <div>
                        <asp:RadioButtonList runat="server" ID="rblGender">
                            <asp:ListItem Text="Female" Value="0" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txbBirthday" MaxLength="10" placeholder="Birthday"></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txbTel1" placeholder="Main Contact Telephone No."></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txbTel2" placeholder="Cellphone No."></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txbTel3" placeholder="Home Telephone No."></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txbAddr" Height="60px" TextMode="MultiLine" Width="200px" placeholder="Address"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button runat="server" ID="btnSubmit" Text="OK" OnClick="btnSubmit_Click" />
                        <asp:Button runat="server" ID="txbCancel" Text="Cancel" OnClick="txbCancel_Click" />
                    </div>
                </fieldset>
            </div>

        </asp:Panel>
    </form>
</body>
</html>
