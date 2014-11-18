// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using System.Xml;
using System.Xml.XPath;
using XPathTests.Common;

namespace XPathTests
{
    public class CreateNavigatorFromXmlReader : ICreateNavigator
    {
        public XPathNavigator CreateNavigatorFromFile(string fileName)
        {
            var stream = FileHelper.CreateStreamFromFile(fileName);
            var reader = XmlReader.Create(stream, new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore });
            var x = new XPathDocument(reader, XmlSpace.Preserve);
            return x.CreateNavigator();
        }

        public XPathNavigator CreateNavigator(string xml)
        {
            var reader = XmlReader.Create(new StringReader(xml), new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore });
            var x = new XPathDocument(reader, XmlSpace.None);
            return x.CreateNavigator();
        }
    }
}
