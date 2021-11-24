<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Conway.ASP.Net.Form.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/CSS/Home.css" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <%-- <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=data_Product.ClientID%>').DataTable();
            $('#<%=data_Assortiment.ClientID%>').DataTable();
            $('#<%=data_Ini.ClientID%>').DataTable();
        })
    </script>



    <%--<script src="https://cdn.datatables.net/1.10.2.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <link src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.css" rel="stylesheet" />
    <script>
        $(function () {
            $("#data_Product").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="rows">
            <div class="row1">
                <div class="meubel-links">
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>

                    <div class="beneden">81</div>
                    <div class="beneden">82</div>
                    <div class="beneden">83</div>
                    <div class="beneden">84</div>
                    <div class="beneden">85</div>
                    <div class="beneden">86</div>
                    <div class="beneden">87</div>
                    <div class="beneden">88</div>
                    <div class="beneden">89</div>
                    <div class="beneden">90</div>
                </div>

                <div class="meubel-midden">
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>

                    <div class="beneden">61</div>
                    <div class="beneden">62</div>
                    <div class="beneden">63</div>
                    <div class="beneden">64</div>
                    <div class="beneden">65</div>
                    <div class="beneden">66</div>
                    <div class="beneden">67</div>
                    <div class="beneden">68</div>
                    <div class="beneden">69</div>
                    <div class="beneden">70</div>
                    <div class="beneden">71</div>
                    <div class="beneden">72</div>
                    <div class="beneden">73</div>
                    <div class="beneden">74</div>
                    <div class="beneden">75</div>
                    <div class="beneden">76</div>
                    <div class="beneden">77</div>
                    <div class="beneden">78</div>
                    <div class="beneden">79</div>
                    <div class="beneden">80</div>

                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>

                    <div class="beneden">41</div>
                    <div class="beneden">42</div>
                    <div class="beneden">43</div>
                    <div class="beneden">44</div>
                    <div class="beneden">45</div>
                    <div class="beneden">46</div>
                    <div class="beneden">47</div>
                    <div class="beneden">48</div>
                    <div class="beneden">49</div>
                    <div class="beneden">50</div>
                    <div class="beneden">51</div>
                    <div class="beneden">52</div>
                    <div class="beneden">53</div>
                    <div class="beneden">54</div>
                    <div class="beneden">55</div>
                    <div class="beneden">56</div>
                    <div class="beneden">57</div>
                    <div class="beneden">58</div>
                    <div class="beneden">59</div>
                    <div class="beneden">60</div>

                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>

                    <div class="beneden">21</div>
                    <div class="beneden">22</div>
                    <div class="beneden">23</div>
                    <div class="beneden">24</div>
                    <div class="beneden">25</div>
                    <div class="beneden">26</div>
                    <div class="beneden">27</div>
                    <div class="beneden">28</div>
                    <div class="beneden">29</div>
                    <div class="beneden">30</div>
                    <div class="beneden">31</div>
                    <div class="beneden">32</div>
                    <div class="beneden">33</div>
                    <div class="beneden">34</div>
                    <div class="beneden">35</div>
                    <div class="beneden">36</div>
                    <div class="beneden">37</div>
                    <div class="beneden">38</div>
                    <div class="beneden">39</div>
                    <div class="beneden">40</div>
                </div>

                <div class="meubel-rechts">
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>

                    <div class="beneden">11</div>
                    <div class="beneden">12</div>
                    <div class="beneden">13</div>
                    <div class="beneden">14</div>
                    <div class="beneden">15</div>
                    <div class="beneden">16</div>
                    <div class="beneden">17</div>
                    <div class="beneden">18</div>
                    <div class="beneden">19</div>
                    <div class="beneden">20</div>

                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>
                    <div class="boven"></div>

                    <div class="beneden">1</div>
                    <div class="beneden">2</div>
                    <div class="beneden">3</div>
                    <div class="beneden">4</div>
                    <div class="beneden">5</div>
                    <div class="beneden">6</div>
                    <div class="beneden">7</div>
                    <div class="beneden">8</div>
                    <div class="beneden">9</div>
                    <div class="beneden">10</div>
                </div>

                <div class="info-kolom">
                </div>
            </div>

            <div class="row2">
                <div class="import-export">
                    <%--<input class="btn" type="file" name="file" />
                    <input type="submit" value="Upload" />--%>
                    <div class="form-group">
                      <asp:FileUpload 
                        class="btn" 
                        ID="btn_import" 
                        runat="server"
                        Text="Import"/>
                        <asp:Button 
                            Text="Upload" 
                            runat="server"
                            OnClick="Btn_Import_Click"
                            class="btn"/>
                    </div>
                </div>

                <div class="fabrikanten">
                    <asp:Button
                        ID="btn_BAT_C"
                        runat="server"
                        Text="BAT_C"
                        OnClick="BAT_C_Click"
                        class="btn" />

                    <asp:Button
                        ID="btn_BAT_T"
                        runat="server"
                        Text="BAT_T"
                        OnClick="BAT_T_Click"
                        class="btn" />

                    <asp:Button
                        ID="btn_ITB_C"
                        runat="server"
                        Text="ITB_C"
                        OnClick="ITB_C_Click"
                        class="btn" />

                    <asp:Button
                        ID="btn_ITB_T"
                        runat="server"
                        Text="ITB_T"
                        OnClick="ITB_T_Click"
                        class="btn" />

                    <asp:Button
                        ID="btn_JTI_C"
                        runat="server"
                        Text="JTI_C"
                        OnClick="JTI_C_Click"
                        class="btn" />

                    <asp:Button
                        ID="btn_JTI_T"
                        runat="server"
                        Text="JTI_T"
                        OnClick="JTI_T_Click"
                        class="btn" />

                    <asp:Button
                        ID="btn_PMI_C"
                        runat="server"
                        Text="PMI_C"
                        OnClick="PMI_C_Click"
                        class="btn" />
                </div>
            </div>

            <div class="row3">
                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                    <asp:GridView ID="data_Ini" runat="server" class="sortTable" CssClass="display compact">
                    </asp:GridView>
                </div>

                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                    <asp:GridView ID="data_Product" runat="server" class="sortTable" CssClass="display compact">
                    </asp:GridView>
                </div>

                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                    <asp:GridView ID="data_Assortiment" runat="server" class="sortTable" CssClass="display compact">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=data_Product.ClientID%>').DataTable();
            $('#<%=data_Assortiment.ClientID%>').DataTable();
            $('#<%=data_Ini.ClientID%>').DataTable();
        })
</script>

